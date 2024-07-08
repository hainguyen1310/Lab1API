using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Models;

public partial class WebProductApp2Context : DbContext
{
    public WebProductApp2Context()
    {
    }

    public WebProductApp2Context(DbContextOptions<WebProductApp2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryNews> CategoryNews { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StudentWeb"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B3B7C1D8B");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<CategoryNews>(entity =>
        {
            entity.HasKey(e => e.CategoryNewsId).HasName("PK__Category__6969AA28F5B78718");

            entity.Property(e => e.CategoryNewsId).HasColumnName("CategoryNewsID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__954EBDD3190715FE");

            entity.Property(e => e.NewsId).HasColumnName("NewsID");
            entity.Property(e => e.CategoryNewsId).HasColumnName("CategoryNewsID");
            entity.Property(e => e.DateUpdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Metacontent).HasColumnType("ntext");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.CategoryNews).WithMany(p => p.News)
                .HasForeignKey(d => d.CategoryNewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_New_CategoryNew");

            entity.HasOne(d => d.UserPostNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.UserPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_New_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFDD88940A");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.UserOrderNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED6957C96B");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Decription).HasMaxLength(200);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .HasColumnName("ImageURL");
            entity.Property(e => e.MetaContent).HasColumnType("ntext");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Product_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A7B23EACA");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC18EE4EDC");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053467B07775").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F2845656EF83BD").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

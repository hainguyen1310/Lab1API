using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public int? UnitInStock { get; set; }

    public int? UserId { get; set; }

    public DateOnly? DateUpdate { get; set; }

    public bool? Status { get; set; }

    public string? ImageUrl { get; set; }

    public string? Decription { get; set; }

    public string? MetaContent { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}

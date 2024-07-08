using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class News
{
    public int NewsId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Metacontent { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateOnly? DateUpdate { get; set; }

    public int UserPost { get; set; }

    public bool Status { get; set; }

    public int CategoryNewsId { get; set; }

    public virtual CategoryNews CategoryNews { get; set; } = null!;

    public virtual User UserPostNavigation { get; set; } = null!;
}

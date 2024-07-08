using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class CategoryNews
{
    public int CategoryNewsId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}

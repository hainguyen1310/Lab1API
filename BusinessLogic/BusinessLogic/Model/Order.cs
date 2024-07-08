using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserOrder { get; set; }

    public DateOnly DateOrder { get; set; }

    public virtual User UserOrderNavigation { get; set; } = null!;
}

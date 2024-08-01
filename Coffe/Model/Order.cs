using System;
using System.Collections.Generic;

namespace Coffe.Model;

public partial class Order
{
    public int OrderNumber { get; set; }

    public string? OrderList { get; set; }

    public string? UserName { get; set; }

    public string? Address { get; set; }

    public int? IdBarista { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public virtual User? IdBaristaNavigation { get; set; }
}

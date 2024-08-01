using System;
using System.Collections.Generic;

namespace Coffe.Model;

public partial class Product
{
    public int Article { get; set; }

    public int? IdCategory { get; set; }

    public string? ProductName { get; set; }

    public int? Cost { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }
}

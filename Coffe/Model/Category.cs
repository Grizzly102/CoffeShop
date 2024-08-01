using System;
using System.Collections.Generic;

namespace Coffe.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? CategoryProduct { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

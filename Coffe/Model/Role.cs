using System;
using System.Collections.Generic;

namespace Coffe.Model;

public partial class Role
{
    public int IdRole { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

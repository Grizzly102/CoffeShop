using System;
using System.Collections.Generic;

namespace Coffe.Model;

public partial class User
{
    public int IdUser { get; set; }

    public int? IdRole { get; set; }

    public string? FullName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

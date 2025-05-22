using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class RoleU
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

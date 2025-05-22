using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class User
{
    public int UserId { get; set; }

    public string NameU { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordU { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string AddressU { get; set; } = null!;

    public string BankCard { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual RoleU Role { get; set; } = null!;
}

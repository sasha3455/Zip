using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class StatusOrder
{
    public int StatusOrderId { get; set; }

    public string StatusName { get; set; } = null!;

    public string StatusDescriotion { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

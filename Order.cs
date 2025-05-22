using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int Quantity { get; set; }

    public int StatusOrderId { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ProductT Product { get; set; } = null!;

    public virtual StatusOrder StatusOrder { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public int PaymentMethodId { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}

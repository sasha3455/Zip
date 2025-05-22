using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class ProductT
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string NameP { get; set; } = null!;

    public string Size { get; set; } = null!;

    public string DescriptionP { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

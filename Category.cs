using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductT> ProductTs { get; set; } = new List<ProductT>();
}

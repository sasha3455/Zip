﻿using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Rating { get; set; }

    public DateOnly ReviewDate { get; set; }

    public string Comment { get; set; } = null!;

    public virtual ProductT Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

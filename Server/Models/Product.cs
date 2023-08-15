using System;
using System.Collections.Generic;

namespace ProductTest.Server.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}

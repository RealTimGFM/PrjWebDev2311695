using System;
using System.Collections.Generic;

namespace PrjWebDev2311695.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

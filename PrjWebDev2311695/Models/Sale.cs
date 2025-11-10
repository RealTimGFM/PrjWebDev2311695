using System;
using System.Collections.Generic;

namespace PrjWebDev2311695.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateOnly SaleDate { get; set; }

    public string Comment { get; set; } = null!;

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

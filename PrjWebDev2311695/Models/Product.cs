using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrjWebDev2311695.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required, StringLength(120)]
    public string Description { get; set; } = null!;
    [Range(0.01, 2500), Precision(8, 2)]
    public decimal Price { get; set; }
    [Range(0, 120)]
    public int Quantity { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

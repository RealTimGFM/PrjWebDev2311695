using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrjWebDev2311695.Models;

public partial class Sale
{
    [Key]
    public int SaleId { get; set; }
    [PastDate]
    public DateOnly SaleDate { get; set; }
    [Required, StringLength(200)]
    public string Comment { get; set; } = null!;
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int ProductId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

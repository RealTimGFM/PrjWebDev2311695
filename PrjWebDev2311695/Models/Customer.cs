using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrjWebDev2311695.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required, StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Required, StringLength(50)]
    public string LastName { get; set; } = null!;
    [Required, StringLength(120)]
    public string AddressLine { get; set; } = null!;
    [Required, StringLength(7)]
    public string PostalCode { get; set; } = null!;
    [Required, Phone, StringLength(20)]
    public string Phone { get; set; } = null!;
    [Required, RegularExpression(@"^\d{16}$")]
    public string CreditCard { get; set; } = null!;
    [Required, EmailAddress, StringLength(120)]
    public string Email { get; set; } = null!;
    [Required]
    public int CityId { get; set; }

    public City? City { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

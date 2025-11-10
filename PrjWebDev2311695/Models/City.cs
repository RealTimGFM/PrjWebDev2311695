using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrjWebDev2311695.Models;

public partial class City
{
    [Key]
    public int CityId { get; set; }
    [Required, StringLength(60)]
    public string CityName { get; set; } = null!;
    [Required, StringLength(60)]
    public string Province { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}

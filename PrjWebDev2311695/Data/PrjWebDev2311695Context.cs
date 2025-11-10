using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrjWebDev2311695.Models;

namespace PrjWebDev2311695.Data
{
    public class PrjWebDev2311695Context : DbContext
    {
        public PrjWebDev2311695Context (DbContextOptions<PrjWebDev2311695Context> options)
            : base(options)
        {
        }

        public DbSet<PrjWebDev2311695.Models.Customer> Customer { get; set; } = default!;
        public DbSet<PrjWebDev2311695.Models.Product> Product { get; set; } = default!;
        public DbSet<PrjWebDev2311695.Models.Sale> Sale { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvidenceVozidel.Models;

namespace EvidenceVozidel.Data
{
    public class EvidenceVozidelContext : DbContext
    {
        public EvidenceVozidelContext (DbContextOptions<EvidenceVozidelContext> options)
            : base(options)
        {
        }

        public DbSet<EvidenceVozidel.Models.Automobil> Automobil { get; set; } = default!;
    }
}

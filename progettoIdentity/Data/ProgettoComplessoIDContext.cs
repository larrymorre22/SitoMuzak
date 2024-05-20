using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoComplessoID.Models;

namespace ProgettoComplessoID.Data
{
    public class ProgettoComplessoIDContext : DbContext
    {
        public ProgettoComplessoIDContext (DbContextOptions<ProgettoComplessoIDContext> options)
            : base(options)
        {
        }

        public DbSet<ProgettoComplessoID.Models.Album> Album { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.Acquisto> Acquisto { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.Buono> Buono { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.Documento> Documento { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.DVD> DVD { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.Gadget> Gadget { get; set; } = default!;

        public DbSet<ProgettoComplessoID.Models.Vendita> Vendita { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using PruebaAFP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaAFP.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TipoTramite> TipoTramites { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}

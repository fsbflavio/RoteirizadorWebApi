using Microsoft.EntityFrameworkCore;
using Roterizador.Domain.Model;
using Roterizador.Persistence.EntityConfigurations;

namespace Roterizador.EntityPostgres
{
    public class RoterizadorContext : DbContext
    {
        public RoterizadorContext(DbContextOptions<RoterizadorContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new CoordinateConfiguration());
        }

        public DbSet<Route> Routes { get; set; }
    }
}
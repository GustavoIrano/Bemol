using bemol.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bemol.Data.Context
{
    public class BemolDbContext : DbContext
    {
        public BemolDbContext(DbContextOptions<BemolDbContext> options):base(options){}


        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BemolDbContext).Assembly);

            //Impedindo o delete em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

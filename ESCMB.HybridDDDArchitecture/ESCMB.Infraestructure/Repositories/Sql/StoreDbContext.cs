using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    /// <summary>
    /// Contexto de almacenamiento en base de datos. Aca se definen los nombres de 
    /// las tablas, y los mapeos entre los objetos
    /// </summary>
    internal class StoreDbContext : DbContext
    {
        public DbSet<Domain.Entities.DummyEntity> DummyEntity { get; set; }

        public DbSet<Domain.Entities.Customer> Customer { get; set; }

        public DbSet<Domain.Entities.Account> Account { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected StoreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.DummyEntity>().ToTable("DummyEntity");
            modelBuilder.Entity<Domain.Entities.Customer>().ToTable("Customer");
            modelBuilder.Entity<Domain.Entities.Account>().ToTable("Account");
        }

    }
}

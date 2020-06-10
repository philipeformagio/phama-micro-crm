using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Model.Entities;
using System.Linq;

namespace PhamaMicroCrm.Data.Context
{
    public class PhamaMicroCrmContext : DbContext
    {
        public PhamaMicroCrmContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyUnit> CompanyUnits { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PhamaMicroCrmContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

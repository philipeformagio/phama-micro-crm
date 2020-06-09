using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Mappings
{
    public class CompanyUnitMapping : IEntityTypeConfiguration<CompanyUnit>
    {
        public void Configure(EntityTypeBuilder<CompanyUnit> builder)
        {
            builder.HasKey(cu => cu.Id);

            builder.Property(cu => cu.Phone_1)
                   .HasColumnType("varchar(50)");

            builder.Property(cu => cu.Phone_2)
                   .HasColumnType("varchar(50)");

            builder.Property(cu => cu.Phone_3)
                   .HasColumnType("varchar(50)");

            // 1 : N => CompanyUnit : Contacts
            builder.HasMany(cu => cu.Contacts)
                   .WithOne(c => c.CompanyUnit)
                   .HasForeignKey(c => c.CompanyUnitId);

            // 1 : 1 => CompanyUnit : Address
            builder.HasOne(cu => cu.Address)
                   .WithOne(a => a.CompanyUnit);

            builder.ToTable("CompanyUnits");
        }
    }
}

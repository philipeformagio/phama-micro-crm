using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(c => c.Field)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Active)
                   .IsRequired()
                   .HasColumnType("bit");

            // 1 : N => Company : CompanyUnit
            builder.HasMany(c => c.CompanyUnits)
                   .WithOne(cu => cu.Company)
                   .HasForeignKey(cu => cu.CompanyId);

            builder.ToTable("Companies");
        }
    }
}

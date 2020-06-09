using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                   .HasColumnType("varchar(200)");

            builder.Property(a => a.ZipCode)
                   .HasColumnType("varchar(8)");

            builder.Property(a => a.State)
                   .HasColumnType("varchar(15)");

            builder.Property(a => a.City)
                   .HasColumnType("varchar(50)");

            builder.ToTable("Addresses");
        }
    }
}

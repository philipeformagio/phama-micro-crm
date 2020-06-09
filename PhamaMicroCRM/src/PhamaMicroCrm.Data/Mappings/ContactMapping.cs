using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Phone_1)
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Phone_2)
                   .HasColumnType("varchar(100)");

            builder.ToTable("Contacts");
        }
    }
}

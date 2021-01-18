using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Text)
                   .IsRequired()
                   .HasColumnType("varchar(500)");

            builder.Property(l => l.Type)
                   .IsRequired()
                   .HasColumnType("varchar(50)");
        }
    }
}

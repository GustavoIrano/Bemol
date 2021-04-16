using bemol.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bemol.Data.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                        .IsRequired()
                        .HasColumnType("varchar(250)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasColumnType("varchar(12)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Customers", "bemol");


        }
    }
}

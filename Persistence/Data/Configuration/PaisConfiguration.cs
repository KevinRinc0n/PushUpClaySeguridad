using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");

        builder.Property(c => c.NombrePais)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new Pais { Id = 1, NombrePais = "Colombia" },
            new Pais { Id = 2, NombrePais = "Estados Unidos" }
        );
    }
}
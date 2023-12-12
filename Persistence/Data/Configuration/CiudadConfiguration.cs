using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(c => c.NombreCiudad)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.IdDepartamentoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdDepartamentoFk);

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.IdDepartamentoFk);

        builder.HasData(
            new Ciudad { Id = 1, NombreCiudad = "Bucaramanga", IdDepartamentoFk = 1},
            new Ciudad { Id = 2, NombreCiudad = "Piedecuesta", IdDepartamentoFk = 1},
            new Ciudad { Id = 3, NombreCiudad = "Giron", IdDepartamentoFk = 1}
        );
    }
}
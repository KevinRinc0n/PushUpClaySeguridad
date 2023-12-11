using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(c => c.IdPaisFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.NombreDepartamento)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.IdPaisFk);

        builder.HasData(
            new Departamento { Id = 1, NombreDepartamento = "Santander", IdPaisFk = 1},
            new Departamento { Id = 2, NombreDepartamento = "California", IdPaisFk = 2}
        );
    }
}
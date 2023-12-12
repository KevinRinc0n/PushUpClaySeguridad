using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("contrato");

        builder.Property(c => c.IdClienteFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdEmpleadoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdEstadoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.FechaContrato)
        .IsRequired();

        builder.Property(c => c.FechaFin)
        .IsRequired();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdClienteFk);

        builder.Ignore(p => p.Persona);

        builder.HasOne(p => p.Personaa)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdEmpleadoFk);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Contratos)
        .HasForeignKey(p => p.IdEstadoFk);

        builder.HasData(
            new Contrato { Id = 1, IdEstadoFk = 1, IdClienteFk = 2, IdEmpleadoFk = 1, FechaContrato = new DateOnly (2023, 8, 3), FechaFin = new DateOnly (2023, 10, 2)},
            new Contrato { Id = 2, IdEstadoFk = 2, IdClienteFk = 1, IdEmpleadoFk = 2, FechaContrato = new DateOnly (2023, 7, 23), FechaFin = new DateOnly (2023, 8, 12)}
        );
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("programacion");

        builder.Property(c => c.IdContratoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdTurnoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdEmpleadoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.Contrato)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdContratoFk);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdEmpleadoFk);

        builder.HasOne(p => p.Turno)
        .WithMany(p => p.Programaciones)
        .HasForeignKey(p => p.IdTurnoFk);

        builder.HasData(
            new Programacion { Id = 1, IdContratoFk =  1, IdTurnoFk = 2, IdEmpleadoFk = 1},
            new Programacion { Id = 2, IdContratoFk =  2, IdTurnoFk = 1, IdEmpleadoFk = 1}
        );
    }
}
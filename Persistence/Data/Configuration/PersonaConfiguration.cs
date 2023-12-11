using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);
        
        builder.Property(c => c.IdPersona)
        .IsRequired()
        .HasColumnType("int");

        builder.HasIndex(c => c.IdPersona).IsUnique();

        builder.Property(c => c.FechaReg)
        .IsRequired();

        builder.Property(c => c.IdTipoPersonaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdCategoriaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdCiudadFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.CategoriaPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdCategoriaFk);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdCiudadFk);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPersonaFk);

        builder.HasData(
            new Persona { Id = 1, Nombre = "Carlos Marin" , IdPersona = 4324, FechaReg = new DateOnly (2023, 1, 1), IdTipoPersonaFk = 1, IdCategoriaFk = 2, IdCiudadFk = 1},
            new Persona { Id = 2, Nombre = "Maria Gonzales" , IdPersona = 333, FechaReg = new DateOnly (2023, 2, 25), IdTipoPersonaFk = 2, IdCategoriaFk = 1, IdCiudadFk = 2}
        );
    }
}
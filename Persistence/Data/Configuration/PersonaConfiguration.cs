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
            new Persona { Id = 2, Nombre = "Maria Gonzales" , IdPersona = 333, FechaReg = new DateOnly (2023, 2, 25), IdTipoPersonaFk = 2, IdCategoriaFk = 1, IdCiudadFk = 2},
            new Persona { Id = 3, Nombre = "Jose Gomez" , IdPersona = 5453, FechaReg = new DateOnly (2000, 2, 15), IdTipoPersonaFk = 2, IdCategoriaFk = 1, IdCiudadFk = 2},
            new Persona { Id = 4, Nombre = "Luis Villa" , IdPersona = 1274, FechaReg = new DateOnly (2003, 7, 3), IdTipoPersonaFk = 2, IdCategoriaFk = 2, IdCiudadFk = 1},
            new Persona { Id = 5, Nombre = "Jose Manrrique" , IdPersona = 89, FechaReg = new DateOnly (2015, 4, 1), IdTipoPersonaFk = 1, IdCategoriaFk = 1, IdCiudadFk = 1},
            new Persona { Id = 6, Nombre = "Emanuel Torres" , IdPersona = 664, FechaReg = new DateOnly (2019, 11, 21), IdTipoPersonaFk = 1, IdCategoriaFk = 1, IdCiudadFk = 2},
            new Persona { Id = 7, Nombre = "Luna Cardenas" , IdPersona = 43244, FechaReg = new DateOnly (2023, 6, 12), IdTipoPersonaFk = 1, IdCategoriaFk = 1, IdCiudadFk = 2}
        );
    }
}
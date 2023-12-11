using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("contactoPersona");

        builder.Property(c => c.Descripcion)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(c => c.Descripcion).IsUnique();

        builder.Property(c => c.IdPersonaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdTipoContactoFk)
        .IsRequired()
        .HasColumnType("int");

        builder.HasOne(p => p.persona)
        .WithMany(p => p.ContactosPersonas)
        .HasForeignKey(p => p.IdPersonaFk);

        builder.HasOne(p => p.TipoContacto)
        .WithMany(p => p.ContactosPersonas)
        .HasForeignKey(p => p.IdTipoContactoFk);

        builder.HasData(
            new ContactoPersona { Id = 1, Descripcion = "Madre", IdPersonaFk = 1, IdTipoContactoFk = 2},
            new ContactoPersona { Id = 2, Descripcion = "Abuelo", IdPersonaFk = 2, IdTipoContactoFk = 1}
        );
    }
}
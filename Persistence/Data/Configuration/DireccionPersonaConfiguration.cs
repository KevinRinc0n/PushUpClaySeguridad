using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> builder)
    {
        builder.ToTable("direccionPersona");

        builder.Property(c => c.IdPersonaFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdTipoDireccionFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.CallePrincipal)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.CalleSecundaria)
        .HasMaxLength(50);

        builder.Property(c => c.Avenida)
        .HasMaxLength(50);

        builder.Property(c => c.InformacionAdicional)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.DireccionesPersonas)
        .HasForeignKey(p => p.IdPersonaFk);

        builder.HasOne(p => p.TipoDireccion)
        .WithMany(p => p.DireccionesPersonas)
        .HasForeignKey(p => p.IdTipoDireccionFk);

        builder.HasData(
            new DireccionPersona { Id = 1, IdTipoDireccionFk = 1, IdPersonaFk = 2, CallePrincipal = "Cll 23 A", CalleSecundaria = "Cll 1", Avenida = "Av arenales", InformacionAdicional = "Cerca de la iglesia"},
            new DireccionPersona { Id = 2, IdTipoDireccionFk = 2, IdPersonaFk = 1, CallePrincipal = "Cll 55", CalleSecundaria = "Cll 79", Avenida = "Av 1 Casanare", InformacionAdicional = "Detras del estadio"}
        );
    }
}
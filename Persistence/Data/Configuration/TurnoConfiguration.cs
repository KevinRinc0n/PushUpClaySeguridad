using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.ToTable("Turno");

        builder.Property(c => c.NombreTurno)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(c => c.HoraInicioTurno)
        .IsRequired();

        builder.Property(c => c.HoraFinTurno)
        .IsRequired();

        builder.HasData(
            new Turno { Id = 1, NombreTurno =  "Diurno", HoraInicioTurno = TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(30)) , HoraFinTurno = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(2))},
            new Turno { Id = 2, NombreTurno =  "Nocturno", HoraInicioTurno = TimeSpan.FromHours(3).Add(TimeSpan.FromMinutes(33)), HoraFinTurno = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(58))}
        );
    }
}
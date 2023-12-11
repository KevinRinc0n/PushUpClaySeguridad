using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
    {
        builder.ToTable("categoriaPersona");

        builder.Property(c => c.NombreCategoria)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasData(
            new CategoriaPersona { Id = 1, NombreCategoria = "Vigilantes" }        
            );
    }
}
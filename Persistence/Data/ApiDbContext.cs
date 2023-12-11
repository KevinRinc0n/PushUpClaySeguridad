using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> RolesUsuarios { get; set; }
    public DbSet<User> Usuarios { get; set; }
    public DbSet<CategoriaPersona> CategoriasPersonas { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<ContactoPersona> ContactosPersonas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DireccionPersona> DireccionesPersonas { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Programacion> Programaciones { get; set; }
    public DbSet<TipoContacto> TiposContactos { get; set; }
    public DbSet<TipoDireccion> TiposDirecciones { get; set; }
    public DbSet<TipoPersona> TiposPersonas { get; set; }
    public DbSet<Turno> Turnos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    }
}
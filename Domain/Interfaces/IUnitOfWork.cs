using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Usuarios { get; }
    ICategoriaPersona CategoriasPersonas { get; }
    ICiudad Ciudades { get; }
    IContactoPersona ContactosPersonas { get; }
    IContrato Contratos { get; }
    IDepartamento Departamentos { get; }
    IDireccionPersona DireccionesPersonas { get; }
    IEstado Estados { get; }
    IPais Paises { get; }
    IPersona Personas { get; }
    IProgramacion Programaciones { get; }
    ITipoContacto TiposContactos { get; }
    ITipoDireccion TiposDirecciones { get; }
    ITipoPersona TiposPersonas { get; }
    ITurno Turnos { get; }


    Task<int> SaveAsync();
}
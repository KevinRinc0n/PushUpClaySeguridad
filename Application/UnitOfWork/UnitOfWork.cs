using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
   
    private IRol _roles;
    private IUser _usuarios;
    private ICategoriaPersona _categoriasPersonas;
    private ICiudad _ciudades;
    private IContactoPersona _contactosPersonas;
    private IContrato _contratos;
    private IDepartamento _departamentos;
    private IDireccionPersona _direccionesPersonas;
    private IEstado _estados;
    private IPais _paises;
    private IPersona _personas;
    private IProgramacion _programaciones;
    private ITipoContacto _tiposContactos;
    private ITipoDireccion _tiposDirecciones;
    private ITipoPersona _tiposPersonas;
    private ITurno _turnos;


    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public ICategoriaPersona CategoriasPersonas
    {
        get
        {
            if (_categoriasPersonas == null)
            {
                _categoriasPersonas = new CategoriaPersonaRepository(_context);
            }
            return _categoriasPersonas;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IContactoPersona ContactosPersonas
    {
        get
        {
            if (_contactosPersonas == null)
            {
                _contactosPersonas = new ContactoPersonaRepository(_context);
            }
            return _contactosPersonas;
        }
    }

    public IContrato Contratos
    {
        get
        {
            if (_contratos == null)
            {
                _contratos = new ContratoRepository(_context);
            }
            return _contratos;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IDireccionPersona DireccionesPersonas
    {
        get
        {
            if (_direccionesPersonas == null)
            {
                _direccionesPersonas = new DireccionPersonaRepository(_context);
            }
            return _direccionesPersonas;
        }
    }

    public IEstado Estados
    {
        get
        {
            if (_estados == null)
            {
                _estados = new EstadoRepository(_context);
            }
            return _estados;
        }
    }

    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(_context);
            }
            return _personas;
        }
    }

    public IProgramacion Programaciones
    {
        get
        {
            if (_programaciones == null)
            {
                _programaciones = new ProgramacionRepository(_context);
            }
            return _programaciones;
        }
    }

    public ITipoContacto TiposContactos
    {
        get
        {
            if (_tiposContactos == null)
            {
                _tiposContactos = new TipoContactoRepository(_context);
            }
            return _tiposContactos;
        }
    }

    public ITipoDireccion TiposDirecciones
    {
        get
        {
            if (_tiposDirecciones == null)
            {
                _tiposDirecciones = new TipoDireccionRepository(_context);
            }
            return _tiposDirecciones;
        }
    }

    public ITipoPersona TiposPersonas
    {
        get
        {
            if (_tiposPersonas == null)
            {
                _tiposPersonas = new TipoPersonaRepository(_context);
            }
            return _tiposPersonas;
        }
    }

    public ITurno Turnos
    {
        get
        {
            if (_turnos == null)
            {
                _turnos = new TurnoRepository(_context);
            }
            return _turnos;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUser Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UserRepository(_context);
            }
            return _usuarios;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
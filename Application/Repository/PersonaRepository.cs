using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly ApiDbContext _context;

    public PersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Persona>> todosEmpleados()
    {
        var todos = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 1)
        .Include(c => c.CategoriaPersona)
        .Include(c => c.TipoPersona)
        .Include(c => c.Ciudad)
        .ThenInclude(c => c.Departamento)
        .ThenInclude(c => c.Pais)
        .ToListAsync();

        return todos;
    }

    public async Task<IEnumerable<Persona>> todosVigilantes()
    {
        var vigilantes = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 1 && c.IdCategoriaFk == 1)
        .Include(c => c.CategoriaPersona)
        .Include(c => c.TipoPersona)
        .ToListAsync();

        return vigilantes;
    }

    public async Task<IEnumerable<Persona>> numerosContactoVigilante()
    {
        var numerosContacto = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 1 && c.IdCategoriaFk == 1)
        .Include(c => c.CategoriaPersona)
        .Include(c => c.TipoPersona)
        .Include(c => c.ContactosPersonas)
        .ThenInclude(c => c.TipoContacto)
        .ToListAsync();

        return numerosContacto;
    }

    public async Task<IEnumerable<Persona>> clientesBucaramanga()
    {
        var clientesDeBucaramanga = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 2 && c.IdCiudadFk == 1)
        .Include(c => c.TipoPersona)
        .Include(c => c.Ciudad)
        .ThenInclude(c => c.Departamento)
        .ThenInclude(c => c.Pais)
        .ToListAsync();

        return clientesDeBucaramanga;
    }

    public async Task<IEnumerable<Persona>> clientesGironYPiedecuesta()
    {
        var clientesDeGironYPiedecuesta = await _context.Personas
            .Where(c => (c.IdCiudadFk == 2 || c.IdCiudadFk == 3) && c.IdTipoPersonaFk == 1) 
            .Include(c => c.TipoPersona)
            .Include(c => c.Ciudad)
            .ThenInclude(c => c.Departamento)
            .ThenInclude(c => c.Pais)
            .ToListAsync();

        return clientesDeGironYPiedecuesta;
    }

    public async Task<IEnumerable<Persona>> clientesAntiguos()
    {
        var fechaLimite = new DateOnly(2017, 12, 31);
        
        var antiguos = await _context.Personas
            .Where(c => c.IdTipoPersonaFk == 2 && c.FechaReg <= fechaLimite) 
            .Include(c => c.TipoPersona)
            .ToListAsync();

        return antiguos;
    }
}
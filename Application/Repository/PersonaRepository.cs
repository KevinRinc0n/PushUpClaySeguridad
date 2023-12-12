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
        .ToListAsync();

        return todos;
    }

    public async Task<IEnumerable<Persona>> todosVigilantes()
    {
        var vigilantes = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 1 && c.IdCategoriaFk == 1)
        
        .ToListAsync();

        return vigilantes;
    }

    public async Task<IEnumerable<Persona>> numerosContactoVigilante()
    {
        var numerosContacto = await _context.Personas
        .Where(c => c.IdTipoPersonaFk == 1 && c.IdCategoriaFk == 1)
        .Include(c => c.ContactosPersonas)
        .ToListAsync();

        return numerosContacto;
    }

    public async Task<IEnumerable<Persona>> clientesBucaramanga()
    {
        var clientesDeBucaramanga = await _context.Personas
        .Where(c => c.IdPersona == 2 && c.IdCiudadFk == 1)
        .ToListAsync();

        return clientesDeBucaramanga;
    }

    public async Task<IEnumerable<Persona>> clientesGironYPiedecuesta()
    {
        var clientesDeGironYPiedecuesta = await _context.Personas
        .Where(c => c.IdPersona == 2 && c.IdCiudadFk == 2 || c.IdCiudadFk == 3)
        .ToListAsync();

        return clientesDeGironYPiedecuesta;
    }

    public async Task<IEnumerable<Persona>> clientesAntiguos()
    {
        var antiguos = await _context.Personas
        .Where(c => c.IdPersona == 2 && c.FechaReg <= new DateOnly (2017, 12, 31))
        .ToListAsync();

        return antiguos;
    }

    public async Task<IEnumerable<Persona>> empleadosActivos()
    {
        var activos = await _context.Personas
        .Where(c => c.Contratos.Any(co => co.IdEstadoFk == 1))
        .Include(c => c.Contratos)
        .ToListAsync();

        return activos;
    }
}
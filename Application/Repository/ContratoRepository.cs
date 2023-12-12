using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ContratoRepository : GenericRepository<Contrato>, IContrato
{
    private readonly ApiDbContext _context;

    public ContratoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contrato>> activos()
    {
        var activos = await _context.Contratos
        .Where(c => c.IdEstadoFk == 1)
        .Include(c => c.Personaa)
        .Include(c => c.Estado)
        .ToListAsync();

        return activos;
    }
}
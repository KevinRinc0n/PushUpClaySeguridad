using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
{
    private readonly ApiDbContext _context;

    public TipoPersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
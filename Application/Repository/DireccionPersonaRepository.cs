using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DireccionPersonaRepository : GenericRepository<DireccionPersona>, IDireccionPersona
{
    private readonly ApiDbContext _context;

    public DireccionPersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
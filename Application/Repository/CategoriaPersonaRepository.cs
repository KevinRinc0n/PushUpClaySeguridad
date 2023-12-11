using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CategoriaPersonaRepository : GenericRepository<CategoriaPersona>, ICategoriaPersona
{
    private readonly ApiDbContext _context;

    public CategoriaPersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
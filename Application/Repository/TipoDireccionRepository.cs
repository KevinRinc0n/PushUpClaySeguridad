using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipoDireccionRepository : GenericRepository<TipoDireccion>, ITipoDireccion
{
    private readonly ApiDbContext _context;

    public TipoDireccionRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
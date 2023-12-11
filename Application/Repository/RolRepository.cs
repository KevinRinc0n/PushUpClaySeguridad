using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly ApiDbContext _context;

    public RolRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
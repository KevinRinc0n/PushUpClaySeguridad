using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly ApiDbContext _context;

    public CiudadRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
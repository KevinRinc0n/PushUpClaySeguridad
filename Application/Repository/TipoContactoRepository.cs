using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
{
    private readonly ApiDbContext _context;

    public TipoContactoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
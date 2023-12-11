using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TurnoRepository : GenericRepository<Turno>, ITurno
{
    private readonly ApiDbContext _context;

    public TurnoRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
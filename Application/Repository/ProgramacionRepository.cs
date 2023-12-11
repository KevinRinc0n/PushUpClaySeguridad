using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ProgramacionRepository : GenericRepository<Programacion>, IProgramacion
{
    private readonly ApiDbContext _context;

    public ProgramacionRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
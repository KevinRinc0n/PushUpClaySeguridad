using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly ApiDbContext _context;

    public PersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
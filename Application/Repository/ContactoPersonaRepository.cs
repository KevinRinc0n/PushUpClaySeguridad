using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
{
    private readonly ApiDbContext _context;

    public ContactoPersonaRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
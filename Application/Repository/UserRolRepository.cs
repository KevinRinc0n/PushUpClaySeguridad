using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class UsersRolsRepository : GenericRepository<UserRol>, IUserRol
{
    private readonly ApiDbContext _context;

    public UsersRolsRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }
}
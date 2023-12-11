namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Usuarios { get; }


    Task<int> SaveAsync();
}
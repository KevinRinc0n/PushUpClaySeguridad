using Domain.Entities;

namespace Domain.Interfaces;
public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<Persona>> todosVigilantes();
    Task<IEnumerable<Persona>> numerosContactoVigilante();
    Task<IEnumerable<Persona>> clientesBucaramanga();
    Task<IEnumerable<Persona>> clientesGironYPiedecuesta();
    Task<IEnumerable<Persona>> clientesAntiguos();
    Task<IEnumerable<Persona>> todosEmpleados();
    Task<IEnumerable<Persona>> empleadosActivos();
}
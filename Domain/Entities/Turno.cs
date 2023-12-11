namespace Domain.Entities;

public class Turno : BaseEntity
{
    public string NombreTurno { get; set; }
    public TimeSpan HoraInicioTurno { get; set; }
    public TimeSpan HoraFinTurno { get; set; }
    public ICollection<Programacion> Programaciones { get; set; } 
}
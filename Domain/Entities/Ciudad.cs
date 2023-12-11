namespace Domain.Entities;

public class Ciudad : BaseEntity
{
    public int IdDepartamentoFk { get; set; }
    public Departamento Departamento { get; set; }
    public string NombreCiudad { get; set; }
    public ICollection<Persona> Personas { get; set; }
}
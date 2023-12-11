namespace Domain.Entities;

public class Departamento : BaseEntity
{
    public int IdPaisFk { get; set; }
    public Pais Pais { get; set; }
    public string NombreDepartamento { get; set; }
    public ICollection<Ciudad> Ciudades { get; set; }
}
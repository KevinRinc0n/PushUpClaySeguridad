namespace Api.Dtos;

public class DepartamentoDto
{
    public int Id { get; set; }
    public int IdPaisFk { get; set; }
    public PaisDto Pais { get; set; }
    public string NombreDepartamento { get; set; }
}
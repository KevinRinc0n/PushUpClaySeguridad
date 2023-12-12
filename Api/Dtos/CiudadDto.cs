namespace Api.Dtos;

public class CiudadDto
{
    public int Id { get; set; }
    public int IdDepartamentoFk { get; set; }
    public DepartamentoDto Departamento { get; set; }
    public string NombreCiudad { get; set; }
}
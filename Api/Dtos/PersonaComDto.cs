namespace Api.Dtos;

public class PersonaComDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaReg { get; set; }
    public int IdPersona { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
    public CategoriaDto CategoriaPersona { get; set; }
    public CiudadDto Ciudad { get; set; }
}
namespace Api.Dtos;

public class PersonaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdPersona { get; set; }
    public int IdTipoPersonaFk { get; set; } 
    public TipoPersonaDto TipoPersona { get; set; }
}
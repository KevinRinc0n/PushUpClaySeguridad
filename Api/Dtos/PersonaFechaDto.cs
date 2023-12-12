namespace Api.Dtos;

public class PersonaFechaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaReg { get; set; }
    public int IdPersona { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
}
namespace Api.Dtos;

public class PersonaContactVigilantDto
{
    public int Id { get; set; }
    public int IdPersona { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
    public CategoriaDto CategoriaPersona { get; set; }
    public ICollection<ContactosPersonasDto> ContactosPersonas { get; set; }
}
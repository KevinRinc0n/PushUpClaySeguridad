namespace Api.Dtos;

public class PersonaContactVigilantDto
{
    public int Id { get; set; }
    public int IdPersona { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
    public int IdCategoriaFk { get; set; }
    public CategoriaDto Categoria { get; set; }
    public ICollection<ContactosPersonasDto> ContactosPersonas { get; set; }
}
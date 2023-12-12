namespace Api.Dtos;

public class PersonaVigilantDto
{
    public int Id { get; set; }
    public int IdPersona { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
    public int IdCategoriaFk { get; set; }
    public CategoriaDto Categoria { get; set; }
}
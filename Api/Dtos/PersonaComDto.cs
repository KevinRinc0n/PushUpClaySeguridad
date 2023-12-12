namespace Api.Dtos;

public class PersonaComDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaReg { get; set; }
    public int IdPersona { get; set; }
    public int IdTipoPersonaFk { get; set; } 
    public TipoPersonaDto TipoPersona { get; set; }
    public int IdCategoriaFk { get; set; }
    public CategoriaDto Categoria { get; set; }
    public int IdCiudadFk { get; set; }
    public CiudadDto Ciudad { get; set; }
}
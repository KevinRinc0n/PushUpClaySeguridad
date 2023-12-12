namespace Api.Dtos;

public class ContactosPersonasDto
{
    public string Descripcion { get; set; }
    public int IdPersonaFk { get; set; }
    public PersonaDto persona { get; set; }
    public int IdTipoContactoFk { get; set; }
    public TipoContactoDto TipoContacto { get; set; }
}
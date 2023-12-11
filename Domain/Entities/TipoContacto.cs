namespace Domain.Entities;

public class TipoContacto : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<ContactoPersona> ContactosPersonas { get; set; }
}
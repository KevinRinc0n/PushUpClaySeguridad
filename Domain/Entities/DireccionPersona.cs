namespace Domain.Entities;

public class DireccionPersona : BaseEntity
{
    public string CallePrincipal { get; set; }
    public string CalleSecundaria { get; set; }
    public string Avenida { get; set; }
    public string InformacionAdicional { get; set; }
    public int IdPersonaFk { get; set; }
    public Persona Persona { get; set; }
    public int IdTipoDireccionFk { get; set; }
    public TipoDireccion TipoDireccion { get; set; }
}
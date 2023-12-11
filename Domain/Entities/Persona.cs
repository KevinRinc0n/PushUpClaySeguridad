namespace Domain.Entities;

public class Persona : BaseEntity
{
    public int IdPersona { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaReg { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdCategoriaFk { get; set; }
    public CategoriaPersona CategoriaPersona { get; set; } 
    public int IdCiudadFk { get; set; }
    public Ciudad Ciudad { get; set; } 
    public ICollection<Contrato> Contratos { get; set; } 
    public ICollection<Programacion> Programaciones { get; set; } 
    public ICollection<ContactoPersona> ContactosPersonas { get; set; }
    public ICollection<DireccionPersona> DireccionesPersonas { get; set; }
}
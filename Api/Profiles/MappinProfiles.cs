using Api.Dtos;
using Domain.Entities;
using AutoMapper;

namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Persona, PersonaVigilantDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<CategoriaPersona, CategoriaDto>().ReverseMap();
        CreateMap<Persona, PersonaContactVigilantDto>().ReverseMap();
        CreateMap<ContactoPersona, ContactosPersonasDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<TipoContacto, TipoContactoDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Persona, PersonaComDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Persona, PersonaClientBucaDto>().ReverseMap();
        CreateMap<Persona, PersonaFechaDto>().ReverseMap();
        CreateMap<Contrato, ContratoDto>().ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
    }
}
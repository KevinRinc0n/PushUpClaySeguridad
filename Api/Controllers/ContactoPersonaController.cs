using Domain.Entities;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Helpers;
using Api.Dtos;

namespace Api.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize (Roles= "Administrador")]    

public class ContactoPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContactoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ContactosPersonasDto>>> Get()
    {
        var contactoPersona = await unitofwork.ContactosPersonas.GetAllAsync();
        return mapper.Map<List<ContactosPersonasDto>>(contactoPersona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<ContactosPersonasDto>>> Get([FromQuery]Params contactoPersonaParams)
    {
        var contactoPersona = await unitofwork.ContactosPersonas.GetAllAsync(contactoPersonaParams.PageIndex,contactoPersonaParams.PageSize, contactoPersonaParams.Search);
        var listaContactoPersona = mapper.Map<List<ContactosPersonasDto>>(contactoPersona.registros);
        return new Pager<ContactosPersonasDto>(listaContactoPersona, contactoPersona.totalRegistros,contactoPersonaParams.PageIndex,contactoPersonaParams.PageSize,contactoPersonaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactosPersonasDto>> Get(int id)
    {
        var contactoPersona = await unitofwork.ContactosPersonas.GetByIdAsync(id);
        return mapper.Map<ContactosPersonasDto>(contactoPersona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactoPersona>> Post(ContactoPersona contactoPersonaDto)
    {
        var contactoPersona = this.mapper.Map<ContactoPersona>(contactoPersonaDto);
        this.unitofwork.ContactosPersonas.Add(contactoPersona);
        await unitofwork.SaveAsync();
        if (contactoPersona == null){
            return BadRequest();
        }
        contactoPersonaDto.Id = contactoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = contactoPersonaDto.Id }, contactoPersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ContactoPersona>> Put (int id, [FromBody]ContactoPersona contactoPersonaDto)
    {
        if(contactoPersonaDto == null)
            return NotFound();

        var contactoPersona = this.mapper.Map<ContactoPersona>(contactoPersonaDto);
        unitofwork.ContactosPersonas.Update(contactoPersona);
        await unitofwork.SaveAsync();
        return contactoPersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var contactoPersona = await unitofwork.ContactosPersonas.GetByIdAsync(id);

        if (contactoPersona == null)
        {
            return Notfound();
        }

        unitofwork.ContactosPersonas.Remove(contactoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
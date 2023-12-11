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

public class PersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var persona = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<Persona>>(persona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Persona>>> Get([FromQuery]Params PersonaParams)
    {
        var persona = await unitofwork.Personas.GetAllAsync(PersonaParams.PageIndex,PersonaParams.PageSize, PersonaParams.Search);
        var listaPersona = mapper.Map<List<Persona>>(persona.registros);
        return new Pager<Persona>(listaPersona, persona.totalRegistros,PersonaParams.PageIndex,PersonaParams.PageSize,PersonaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> Get(int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        return mapper.Map<Persona>(persona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(Persona PersonaDto)
    {
        var persona = this.mapper.Map<Persona>(PersonaDto);
        this.unitofwork.Personas.Add(persona);
        await unitofwork.SaveAsync();
        if (persona == null){
            return BadRequest();
        }
        PersonaDto.Id = persona.Id;
        return CreatedAtAction(nameof(Post), new { id = PersonaDto.Id }, PersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Persona>> Put (int id, [FromBody]Persona PersonaDto)
    {
        if(PersonaDto == null)
            return NotFound();

        var persona = this.mapper.Map<Persona>(PersonaDto);
        unitofwork.Personas.Update(persona);
        await unitofwork.SaveAsync();
        return PersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);

        if (persona == null)
        {
            return Notfound();
        }

        unitofwork.Personas.Remove(persona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
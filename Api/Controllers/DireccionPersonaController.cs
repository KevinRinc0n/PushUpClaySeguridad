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

public class DireccionPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DireccionPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DireccionPersona>>> Get()
    {
        var direccionPersona = await unitofwork.DireccionesPersonas.GetAllAsync();
        return mapper.Map<List<DireccionPersona>>(direccionPersona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<DireccionPersona>>> Get([FromQuery]Params direccionPersonaParams)
    {
        var direccionPersona = await unitofwork.DireccionesPersonas.GetAllAsync(direccionPersonaParams.PageIndex,direccionPersonaParams.PageSize, direccionPersonaParams.Search);
        var listaDireccionPersona = mapper.Map<List<DireccionPersona>>(direccionPersona.registros);
        return new Pager<DireccionPersona>(listaDireccionPersona, direccionPersona.totalRegistros,direccionPersonaParams.PageIndex,direccionPersonaParams.PageSize,direccionPersonaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionPersona>> Get(int id)
    {
        var direccionPersona = await unitofwork.DireccionesPersonas.GetByIdAsync(id);
        return mapper.Map<DireccionPersona>(direccionPersona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DireccionPersona>> Post(DireccionPersona DireccionPersonaDto)
    {
        var direccionPersona = this.mapper.Map<DireccionPersona>(DireccionPersonaDto);
        this.unitofwork.DireccionesPersonas.Add(direccionPersona);
        await unitofwork.SaveAsync();
        if (direccionPersona == null){
            return BadRequest();
        }
        DireccionPersonaDto.Id = direccionPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = DireccionPersonaDto.Id }, DireccionPersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DireccionPersona>> Put (int id, [FromBody]DireccionPersona DireccionPersonaDto)
    {
        if(DireccionPersonaDto == null)
            return NotFound();

        var direccionPersona = this.mapper.Map<DireccionPersona>(DireccionPersonaDto);
        unitofwork.DireccionesPersonas.Update(direccionPersona);
        await unitofwork.SaveAsync();
        return DireccionPersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var DireccionPersona = await unitofwork.DireccionesPersonas.GetByIdAsync(id);

        if (DireccionPersona == null)
        {
            return Notfound();
        }

        unitofwork.DireccionesPersonas.Remove(DireccionPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
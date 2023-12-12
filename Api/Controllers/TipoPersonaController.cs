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

public class TipoPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var tipoPersona = await unitofwork.TiposPersonas.GetAllAsync();
        return mapper.Map<List<TipoPersonaDto>>(tipoPersona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoPersonaDto>>> Get([FromQuery]Params TipoPersonaParams)
    {
        var tipoPersona = await unitofwork.TiposPersonas.GetAllAsync(TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize, TipoPersonaParams.Search);
        var listaTipoPersona = mapper.Map<List<TipoPersonaDto>>(tipoPersona.registros);
        return new Pager<TipoPersonaDto>(listaTipoPersona, tipoPersona.totalRegistros,TipoPersonaParams.PageIndex,TipoPersonaParams.PageSize,TipoPersonaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var tipoPersona = await unitofwork.TiposPersonas.GetByIdAsync(id);
        return mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto TipoPersonaDto)
    {
        var TipoPersona = this.mapper.Map<TipoPersona>(TipoPersonaDto);
        this.unitofwork.TiposPersonas.Add(TipoPersona);
        await unitofwork.SaveAsync();
        if (TipoPersona == null){
            return BadRequest();
        }
        TipoPersonaDto.Id = TipoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = TipoPersonaDto.Id }, TipoPersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> Put (int id, [FromBody]TipoPersonaDto TipoPersonaDto)
    {
        if(TipoPersonaDto == null)
            return NotFound();

        var tipoPersona = this.mapper.Map<TipoPersona>(TipoPersonaDto);
        unitofwork.TiposPersonas.Update(tipoPersona);
        await unitofwork.SaveAsync();
        return TipoPersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoPersona = await unitofwork.TiposPersonas.GetByIdAsync(id);

        if (tipoPersona == null)
        {
            return Notfound();
        }

        unitofwork.TiposPersonas.Remove(tipoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
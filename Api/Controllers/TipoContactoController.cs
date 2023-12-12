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

public class TipoContactoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoContactoDto>>> Get()
    {
        var tipoContacto = await unitofwork.TiposContactos.GetAllAsync();
        return mapper.Map<List<TipoContactoDto>>(tipoContacto);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoContactoDto>>> Get([FromQuery]Params TipoContactoParams)
    {
        var tipoContacto = await unitofwork.TiposContactos.GetAllAsync(TipoContactoParams.PageIndex,TipoContactoParams.PageSize, TipoContactoParams.Search);
        var listaTipoContacto = mapper.Map<List<TipoContactoDto>>(tipoContacto.registros);
        return new Pager<TipoContactoDto>(listaTipoContacto, tipoContacto.totalRegistros,TipoContactoParams.PageIndex,TipoContactoParams.PageSize,TipoContactoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoContactoDto>> Get(int id)
    {
        var tipoContacto = await unitofwork.TiposContactos.GetByIdAsync(id);
        return mapper.Map<TipoContactoDto>(tipoContacto);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoContactoDto>> Post(TipoContactoDto TipoContactoDto)
    {
        var tipoContacto = this.mapper.Map<TipoContacto>(TipoContactoDto);
        this.unitofwork.TiposContactos.Add(tipoContacto);
        await unitofwork.SaveAsync();
        if (tipoContacto == null){
            return BadRequest();
        }
        TipoContactoDto.Id = tipoContacto.Id;
        return CreatedAtAction(nameof(Post), new { id = TipoContactoDto.Id }, TipoContactoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoContactoDto>> Put (int id, [FromBody]TipoContactoDto TipoContactoDto)
    {
        if(TipoContactoDto == null)
            return NotFound();

        var tipoContacto = this.mapper.Map<TipoContacto>(TipoContactoDto);
        unitofwork.TiposContactos.Update(tipoContacto);
        await unitofwork.SaveAsync();
        return TipoContactoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoContacto = await unitofwork.TiposContactos.GetByIdAsync(id);

        if (tipoContacto == null)
        {
            return Notfound();
        }

        unitofwork.TiposContactos.Remove(tipoContacto);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
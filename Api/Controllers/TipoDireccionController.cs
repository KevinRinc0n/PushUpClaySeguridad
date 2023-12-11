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

public class TipoDireccionController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoDireccion>>> Get()
    {
        var tipoDireccion = await unitofwork.TiposDirecciones.GetAllAsync();
        return mapper.Map<List<TipoDireccion>>(tipoDireccion);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<TipoDireccion>>> Get([FromQuery]Params TipoDireccionParams)
    {
        var TipoDireccion = await unitofwork.TiposDirecciones.GetAllAsync(TipoDireccionParams.PageIndex,TipoDireccionParams.PageSize, TipoDireccionParams.Search);
        var listaTipoDireccion = mapper.Map<List<TipoDireccion>>(TipoDireccion.registros);
        return new Pager<TipoDireccion>(listaTipoDireccion, TipoDireccion.totalRegistros,TipoDireccionParams.PageIndex,TipoDireccionParams.PageSize,TipoDireccionParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoDireccion>> Get(int id)
    {
        var tipoDireccion = await unitofwork.TiposDirecciones.GetByIdAsync(id);
        return mapper.Map<TipoDireccion>(tipoDireccion);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDireccion>> Post(TipoDireccion TipoDireccionDto)
    {
        var tipoDireccion = this.mapper.Map<TipoDireccion>(TipoDireccionDto);
        this.unitofwork.TiposDirecciones.Add(tipoDireccion);
        await unitofwork.SaveAsync();
        if (tipoDireccion == null){
            return BadRequest();
        }
        TipoDireccionDto.Id = tipoDireccion.Id;
        return CreatedAtAction(nameof(Post), new { id = TipoDireccionDto.Id }, TipoDireccionDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoDireccion>> Put (int id, [FromBody]TipoDireccion TipoDireccionDto)
    {
        if(TipoDireccionDto == null)
            return NotFound();

        var tipoDireccion = this.mapper.Map<TipoDireccion>(TipoDireccionDto);
        unitofwork.TiposDirecciones.Update(tipoDireccion);
        await unitofwork.SaveAsync();
        return TipoDireccionDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoDireccion = await unitofwork.TiposDirecciones.GetByIdAsync(id);

        if (tipoDireccion == null)
        {
            return Notfound();
        }

        unitofwork.TiposDirecciones.Remove(tipoDireccion);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
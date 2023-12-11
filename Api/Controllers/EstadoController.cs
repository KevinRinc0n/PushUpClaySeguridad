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

public class EstadoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estado = await unitofwork.Estados.GetAllAsync();
        return mapper.Map<List<Estado>>(estado);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Estado>>> Get([FromQuery]Params EstadoParams)
    {
        var estado = await unitofwork.Estados.GetAllAsync(EstadoParams.PageIndex,EstadoParams.PageSize, EstadoParams.Search);
        var listaEstado = mapper.Map<List<Estado>>(estado.registros);
        return new Pager<Estado>(listaEstado, estado.totalRegistros,EstadoParams.PageIndex,EstadoParams.PageSize,EstadoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Estado>> Get(int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);
        return mapper.Map<Estado>(estado);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(Estado EstadoDto)
    {
        var estado = this.mapper.Map<Estado>(EstadoDto);
        this.unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();
        if (estado == null){
            return BadRequest();
        }
        EstadoDto.Id = estado.Id;
        return CreatedAtAction(nameof(Post), new { id = EstadoDto.Id }, EstadoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Put (int id, [FromBody]Estado EstadoDto)
    {
        if(EstadoDto == null)
            return NotFound();

        var estado = this.mapper.Map<Estado>(EstadoDto);
        unitofwork.Estados.Update(estado);
        await unitofwork.SaveAsync();
        return EstadoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var estado = await unitofwork.Estados.GetByIdAsync(id);

        if (estado == null)
        {
            return Notfound();
        }

        unitofwork.Estados.Remove(estado);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
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

public class ProgramacionController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Programacion>>> Get()
    {
        var programacion = await unitofwork.Programaciones.GetAllAsync();
        return mapper.Map<List<Programacion>>(programacion);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Programacion>>> Get([FromQuery]Params ProgramacionParams)
    {
        var programacion = await unitofwork.Programaciones.GetAllAsync(ProgramacionParams.PageIndex,ProgramacionParams.PageSize, ProgramacionParams.Search);
        var listaProgramacion = mapper.Map<List<Programacion>>(programacion.registros);
        return new Pager<Programacion>(listaProgramacion, programacion.totalRegistros,ProgramacionParams.PageIndex,ProgramacionParams.PageSize,ProgramacionParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Programacion>> Get(int id)
    {
        var programacion = await unitofwork.Programaciones.GetByIdAsync(id);
        return mapper.Map<Programacion>(programacion);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Programacion>> Post(Programacion ProgramacionDto)
    {
        var programacion = this.mapper.Map<Programacion>(ProgramacionDto);
        this.unitofwork.Programaciones.Add(programacion);
        await unitofwork.SaveAsync();
        if (programacion == null){
            return BadRequest();
        }
        ProgramacionDto.Id = programacion.Id;
        return CreatedAtAction(nameof(Post), new { id = ProgramacionDto.Id }, ProgramacionDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Programacion>> Put (int id, [FromBody]Programacion ProgramacionDto)
    {
        if(ProgramacionDto == null)
            return NotFound();

        var programacion = this.mapper.Map<Programacion>(ProgramacionDto);
        unitofwork.Programaciones.Update(programacion);
        await unitofwork.SaveAsync();
        return ProgramacionDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var programacion = await unitofwork.Programaciones.GetByIdAsync(id);

        if (programacion == null)
        {
            return Notfound();
        }

        unitofwork.Programaciones.Remove(programacion);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
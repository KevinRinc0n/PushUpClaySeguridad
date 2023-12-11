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

public class TurnoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Turno>>> Get()
    {
        var turno = await unitofwork.Turnos.GetAllAsync();
        return mapper.Map<List<Turno>>(turno);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Turno>>> Get([FromQuery]Params TurnoParams)
    {
        var turno = await unitofwork.Turnos.GetAllAsync(TurnoParams.PageIndex,TurnoParams.PageSize, TurnoParams.Search);
        var listaTurno = mapper.Map<List<Turno>>(turno.registros);
        return new Pager<Turno>(listaTurno, turno.totalRegistros,TurnoParams.PageIndex,TurnoParams.PageSize,TurnoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Turno>> Get(int id)
    {
        var turno = await unitofwork.Turnos.GetByIdAsync(id);
        return mapper.Map<Turno>(turno);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Turno>> Post(Turno turnoDto)
    {
        var turno = this.mapper.Map<Turno>(turnoDto);
        this.unitofwork.Turnos.Add(turno);
        await unitofwork.SaveAsync();
        if (turno == null){
            return BadRequest();
        }
        turnoDto.Id = turno.Id;
        return CreatedAtAction(nameof(Post), new { id = turnoDto.Id }, turnoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Turno>> Put (int id, [FromBody]Turno turnoDto)
    {
        if(turnoDto == null)
            return NotFound();

        var turno = this.mapper.Map<Turno>(turnoDto);
        unitofwork.Turnos.Update(turno);
        await unitofwork.SaveAsync();
        return turnoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var turno = await unitofwork.Turnos.GetByIdAsync(id);

        if (turno == null)
        {
            return Notfound();
        }

        unitofwork.Turnos.Remove(turno);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
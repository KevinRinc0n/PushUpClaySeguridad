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
// [Authorize (Roles= "Administrador")]    

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

    public async Task<ActionResult<IEnumerable<PersonaComDto>>> Get()
    {
        var persona = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<PersonaComDto>>(persona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<PersonaComDto>>> Get([FromQuery]Params PersonaParams)
    {
        var persona = await unitofwork.Personas.GetAllAsync(PersonaParams.PageIndex,PersonaParams.PageSize, PersonaParams.Search);
        var listaPersona = mapper.Map<List<PersonaComDto>>(persona.registros);
        return new Pager<PersonaComDto>(listaPersona, persona.totalRegistros,PersonaParams.PageIndex,PersonaParams.PageSize,PersonaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaComDto>> Get(int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        return mapper.Map<PersonaComDto>(persona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaComDto>> Post(PersonaComDto PersonaDto)
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

    public async Task<ActionResult<PersonaComDto>> Put (int id, [FromBody]PersonaComDto PersonaDto)
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

    [HttpGet("todosLosVigilantes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaVigilantDto>>> GetVigilantes()
    {
        var vigilantes = await unitofwork.Personas.todosVigilantes();
        return mapper.Map<List<PersonaVigilantDto>>(vigilantes);
    }

    [HttpGet("numerosContacVigilant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaContactVigilantDto>>> GetContactosVigilantes()
    {
        var contactosVigilantes = await unitofwork.Personas.numerosContactoVigilante();
        return mapper.Map<List<PersonaContactVigilantDto>>(contactosVigilantes);
    }

    [HttpGet("clientesDeBucaramanga")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaClientBucaDto>>> GetClientesBucaramanga()
    {
        var clientesBucaramanga = await unitofwork.Personas.clientesBucaramanga();
        return mapper.Map<List<PersonaClientBucaDto>>(clientesBucaramanga);
    }

    [HttpGet("clientesDeGironYPiedecuesta")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaClientBucaDto>>> GetClientesGironPiedecuesta()
    {
        var clientesGironPiedecuesta = await unitofwork.Personas.clientesGironYPiedecuesta();
        return mapper.Map<List<PersonaClientBucaDto>>(clientesGironPiedecuesta);
    }

    [HttpGet("clientesAntiguos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaFechaDto>>> GetAntiguos()
    {
        var veteranos = await unitofwork.Personas.clientesAntiguos();
        return mapper.Map<List<PersonaFechaDto>>(veteranos);
    }

    [HttpGet("todosLosEmpleados")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaComDto>>> GetTodos()
    {
        var todos = await unitofwork.Personas.todosEmpleados();
        return mapper.Map<List<PersonaComDto>>(todos);
    }

    [HttpGet("contratosActivos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaConActivosDto>>> GetContratosActivos()
    {
        var activos = await unitofwork.Personas.empleadosActivos();
        return mapper.Map<List<PersonaConActivosDto>>(activos);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
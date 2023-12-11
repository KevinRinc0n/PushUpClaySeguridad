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

public class CiudadController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
    {
        var ciudad = await unitofwork.Ciudades.GetAllAsync();
        return mapper.Map<List<Ciudad>>(ciudad);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Ciudad>>> Get([FromQuery]Params CiudadParams)
    {
        var ciudad = await unitofwork.Ciudades.GetAllAsync(CiudadParams.PageIndex,CiudadParams.PageSize, CiudadParams.Search);
        var listaCiudades = mapper.Map<List<Ciudad>>(ciudad.registros);
        return new Pager<Ciudad>(listaCiudades, ciudad.totalRegistros,CiudadParams.PageIndex,CiudadParams.PageSize,CiudadParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Ciudad>> Get(int id)
    {
        var ciudad = await unitofwork.Ciudades.GetByIdAsync(id);
        return mapper.Map<Ciudad>(ciudad);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ciudad>> Post(Ciudad ciudadDto)
    {
        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        this.unitofwork.Ciudades.Add(ciudad);
        await unitofwork.SaveAsync();
        if (ciudad == null){
            return BadRequest();
        }
        ciudadDto.Id = ciudad.Id;
        return CreatedAtAction(nameof(Post), new { id = ciudadDto.Id }, ciudadDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Ciudad>> Put (int id, [FromBody]Ciudad ciudadDto)
    {
        if(ciudadDto == null)
            return NotFound();

        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        unitofwork.Ciudades.Update(ciudad);
        await unitofwork.SaveAsync();
        return ciudadDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var ciudad = await unitofwork.Ciudades.GetByIdAsync(id);

        if (ciudad == null)
        {
            return Notfound();
        }

        unitofwork.Ciudades.Remove(ciudad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
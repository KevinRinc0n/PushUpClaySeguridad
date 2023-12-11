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

public class CategoriaPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CategoriaPersona>>> Get()
    {
        var categoriaPersona = await unitofwork.CategoriasPersonas.GetAllAsync();
        return mapper.Map<List<CategoriaPersona>>(categoriaPersona);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<CategoriaPersona>>> Get([FromQuery]Params categoriasPersonasParams)
    {
        var categoriaPersona = await unitofwork.CategoriasPersonas.GetAllAsync(categoriasPersonasParams.PageIndex,categoriasPersonasParams.PageSize, categoriasPersonasParams.Search);
        var listaCategoriasPersonas = mapper.Map<List<CategoriaPersona>>(categoriaPersona.registros);
        return new Pager<CategoriaPersona>(listaCategoriasPersonas, categoriaPersona.totalRegistros,categoriasPersonasParams.PageIndex,categoriasPersonasParams.PageSize,categoriasPersonasParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaPersona>> Get(int id)
    {
        var categoriaPersonas = await unitofwork.CategoriasPersonas.GetByIdAsync(id);
        return mapper.Map<CategoriaPersona>(categoriaPersonas);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaPersona>> Post(CategoriaPersona categoriaPersonaDto)
    {
        var categoriaPersona = this.mapper.Map<CategoriaPersona>(categoriaPersonaDto);
        this.unitofwork.CategoriasPersonas.Add(categoriaPersona);
        await unitofwork.SaveAsync();
        if (categoriaPersona == null){
            return BadRequest();
        }
        categoriaPersonaDto.Id = categoriaPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = categoriaPersonaDto.Id }, categoriaPersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CategoriaPersona>> Put (int id, [FromBody]CategoriaPersona categoriaPersonaDto)
    {
        if(categoriaPersonaDto == null)
            return NotFound();

        var categoriaPersona = this.mapper.Map<CategoriaPersona>(categoriaPersonaDto);
        unitofwork.CategoriasPersonas.Update(categoriaPersona);
        await unitofwork.SaveAsync();
        return categoriaPersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var categoriaPersona = await unitofwork.CategoriasPersonas.GetByIdAsync(id);

        if (categoriaPersona == null)
        {
            return Notfound();
        }

        unitofwork.CategoriasPersonas.Remove(categoriaPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    // [HttpGet("goldenRetriever")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<MascotaPropietarioDto>>> GetRetriever()
    // {
    //     var mascotaVeterinario = await unitofwork.Mascotas.mascotaGolden();
    //     return mapper.Map<List<MascotaPropietarioDto>>(mascotaVeterinario);
    // }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
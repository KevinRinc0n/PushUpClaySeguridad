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

public class ContratoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ContratoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Contrato>>> Get()
    {
        var contrato = await unitofwork.Contratos.GetAllAsync();
        return mapper.Map<List<Contrato>>(contrato);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<Contrato>>> Get([FromQuery]Params ContratoParams)
    {
        var contrato = await unitofwork.Contratos.GetAllAsync(ContratoParams.PageIndex,ContratoParams.PageSize, ContratoParams.Search);
        var listaContratos = mapper.Map<List<Contrato>>(contrato.registros);
        return new Pager<Contrato>(listaContratos, contrato.totalRegistros,ContratoParams.PageIndex,ContratoParams.PageSize,ContratoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Contrato>> Get(int id)
    {
        var contrato = await unitofwork.Contratos.GetByIdAsync(id);
        return mapper.Map<Contrato>(contrato);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contrato>> Post(Contrato contratoDto)
    {
        var contrato = this.mapper.Map<Contrato>(contratoDto);
        this.unitofwork.Contratos.Add(contrato);
        await unitofwork.SaveAsync();
        if (contrato == null){
            return BadRequest();
        }
        contratoDto.Id = contrato.Id;
        return CreatedAtAction(nameof(Post), new { id = contratoDto.Id }, contratoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Contrato>> Put (int id, [FromBody]Contrato ContratoDto)
    {
        if(ContratoDto == null)
            return NotFound();

        var contrato = this.mapper.Map<Contrato>(ContratoDto);
        unitofwork.Contratos.Update(contrato);
        await unitofwork.SaveAsync();
        return ContratoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var contrato = await unitofwork.Contratos.GetByIdAsync(id);

        if (contrato == null)
        {
            return Notfound();
        }

        unitofwork.Contratos.Remove(contrato);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}
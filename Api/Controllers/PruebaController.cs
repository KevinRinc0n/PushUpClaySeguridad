// using Domain.Entities;
// using AutoMapper;
// using Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
// using Api.Helpers;
// using Api.Dtos;

// namespace Api.Controllers;

// [ApiVersion("1.0")]
// [ApiVersion("1.1")]
// [Authorize (Roles= "Administrador")]    

// public class CitaController : BaseApiController
// {
//     private IUnitOfWork unitofwork;
//     private readonly IMapper mapper;

//     public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
//     {
//         this.unitofwork = unitOfWork;
//         this.mapper = mapper;
//     } 

//     [HttpGet]
//     [MapToApiVersion("1.0")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]

//     public async Task<ActionResult<IEnumerable<CitaGetDto>>> Get()
//     {
//         var cita = await unitofwork.Citas.GetAllAsync();
//         return mapper.Map<List<CitaGetDto>>(cita);
//     }

//     [HttpGet]
//     [MapToApiVersion("1.1")]    
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]

//     public async Task<ActionResult<Pager<CitaGetDto>>> Get([FromQuery]Params citaParams)
//     {
//         var cita = await unitofwork.Citas.GetAllAsync(citaParams.PageIndex,citaParams.PageSize, citaParams.Search);
//         var listaCitas = mapper.Map<List<CitaGetDto>>(cita.registros);
//         return new Pager<CitaGetDto>(listaCitas, cita.totalRegistros,citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
//     }

//     [HttpGet("{id}")]    
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     public async Task<ActionResult<Cita>> Get(int id)
//     {
//         var citas = await unitofwork.Citas.GetByIdAsync(id);
//         return mapper.Map<Cita>(citas);
//     }

//     [HttpPost]    
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<Cita>> Post(Cita citaDto)
//     {
//         var cita = this.mapper.Map<Cita>(citaDto);
//         this.unitofwork.Citas.Add(cita);
//         await unitofwork.SaveAsync();
//         if (cita == null){
//             return BadRequest();
//         }
//         citaDto.Id = cita.Id;
//         return CreatedAtAction(nameof(Post), new { id = citaDto.Id }, citaDto);
//     }

//     [HttpPut("{id}")]    
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]

//     public async Task<ActionResult<Cita>> Put (int id, [FromBody]Cita citaDto)
//     {
//         if(citaDto == null)
//             return NotFound();

//         var cita = this.mapper.Map<Cita>(citaDto);
//         unitofwork.Citas.Update(cita);
//         await unitofwork.SaveAsync();
//         return citaDto;     
//     }

//     [HttpDelete("{id}")]    
//     [ProducesResponseType(StatusCodes.Status404NotFound)]
//     [ProducesResponseType(StatusCodes.Status204NoContent)]

//     public async Task<ActionResult> Delete (int id)
//     {
//         var cita = await unitofwork.Citas.GetByIdAsync(id);

//         if (cita == null)
//         {
//             return Notfound();
//         }

//         unitofwork.Citas.Remove(cita);
//         await unitofwork.SaveAsync();
//         return NoContent();
//     }

//     [HttpGet("goldenRetriever")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<IEnumerable<MascotaPropietarioDto>>> GetRetriever()
//     {
//         var mascotaVeterinario = await unitofwork.Mascotas.mascotaGolden();
//         return mapper.Map<List<MascotaPropietarioDto>>(mascotaVeterinario);
//     }

//     private ActionResult Notfound()
//     {
//         throw new NotImplementedException();
//     }
// }
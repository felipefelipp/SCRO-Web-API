using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Cliente;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.PacienteDto;
using SCRO_Web_API.Models.Extensions;

namespace SCRO_Web_API.Controllers;
[ApiController]
[Route("[controller]")]
public class PacienteController : Controller
{
     SCROContext _context;
     IMapper _mapper;
    public PacienteController(SCROContext context, IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPacientePorId(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.PacienteId == id);
        if (paciente == null) return NotFound();
        var pacienteDto = _mapper.Map<ReadPacienteDto>(paciente);
        return Ok(pacienteDto);
    }

    [HttpGet]
    public IEnumerable<ReadPacienteDto> RecuperaPacientes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var pacientes = _context.Pacientes.Skip(skip).Take(take).ToList();
        var pacientesDto = _mapper.Map<List<ReadPacienteDto>>(pacientes);
        return pacientesDto;
    }

    [HttpPost]
    public IActionResult AdicionaPaciente([FromBody] CreatePacienteDto pacienteDto)
    {
         try
        {
            Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
            paciente.SenhaClassificacao = GerarSenha.Sequencia();
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPacientePorId), new { id = paciente.PacienteId }, paciente);

        } catch (DbUpdateException ex) {

            return BadRequest("Não foi possível inserir este paciente nos sistema, verifique se ele já existe: \n" + ex.Message + ": \n"  + ex.InnerException.Message);
        } catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    [HttpPut]
    public IActionResult AtualizaPaciente(int id, [FromBody] UpdatePacienteDto pacienteDto)
    {
        var paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.PacienteId == id);
        if (paciente == null) return NotFound();
        _mapper.Map(pacienteDto, paciente);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPaciente(int id)
    {
        var paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.PacienteId == id);
        if (paciente == null) return NotFound();
        _context.Pacientes.Remove(paciente);
        _context.SaveChanges();
        return Ok();
    }

    
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Cliente;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.PacienteDto;


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

    /// <summary>
    /// Obtém um paciente pelo ID.
    /// </summary>
    /// <param name="id">ID do paciente.</param>
    /// <returns>O paciente correspondente ao ID.</returns>
    [HttpGet("/Paciente/RecuperaPacientePorId/{id}")]
    [ProducesResponseType(200, Type = typeof(ReadPacienteDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> RecuperaPacientePorId(int id)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.PacienteId == id);
        if (paciente == null) return NotFound($"Paciente com ID {id} não encontrado.");
        var pacienteDto = _mapper.Map<ReadPacienteDto>(paciente);
        return Ok(pacienteDto);
    }


    /// <summary>
    /// Obtém uma lista de pacientes.
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados.</param>
    /// <param name="take">Número máximo de registros a serem retornados.</param>
    /// <returns>Uma lista de pacientes.</returns>
    [HttpGet("/Paciente/RecuperarPacientes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ReadPacienteDto>))]
    public async Task<IEnumerable<ReadPacienteDto>> RecuperarPacientes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var pacientes = await _context.Pacientes.Skip(skip).Take(take).ToListAsync();
        var pacientesDto = _mapper.Map<List<ReadPacienteDto>>(pacientes);
        return pacientesDto;
    }

    /// <summary>
    /// Adiciona um novo paciente.
    /// </summary>
    /// <param name="pacienteDto">Dados do paciente a serem adicionados.</param>
    /// <returns>O paciente recém-adicionado.</returns>
    [HttpPost("/Paciente/AdicionaPaciente")]
    [ProducesResponseType(201, Type = typeof(ReadPacienteDto))]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AdicionarPaciente([FromBody] CreatePacienteDto pacienteDto)
    {
        if (pacienteDto == null)
        {
            return BadRequest("O objeto pacienteDto não pode ser nulo.");
        } 

        try
        {
            Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaPacientePorId), new { id = paciente.PacienteId }, paciente);

        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível inserir este paciente no sistema, verifique se ele já existe: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    /// <summary>
    /// Atualiza os dados de um paciente existente.
    /// </summary>
    /// <param name="id">ID do paciente a ser atualizado.</param>
    /// <param name="pacienteDto">Dados do paciente para atualização.</param>
    /// <returns>Código de status OK se a atualização for bem-sucedida.</returns>
    [HttpPut("/Paciente/AtualizarPaciente/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] UpdatePacienteDto pacienteDto)
    {
        if (pacienteDto == null)
        {
            return BadRequest("O objeto pacienteDto não pode ser nulo.");
        }

        try
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.PacienteId == id);
            if (paciente == null) return NotFound();
            _mapper.Map(pacienteDto, paciente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível inserir este paciente no sistema: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    /// <summary>
    /// Deleta um paciente existente.
    /// </summary>
    /// <param name="id">ID do paciente a ser deletado.</param>
    /// <returns>Código de status OK se a exclusão for bem-sucedida.</returns>
    [HttpDelete("/Paciente/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeletaPaciente(int id)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.PacienteId == id);
        if (paciente == null) return NotFound($"Paciente com ID {id} não encontrado.");
        try
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest($"Não foi possível excluir este paciente do sistema, paciente vinculado a um responsável: {ex.Message}, {ex.InnerException}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro inesperado: {ex.Message}");
        }
    }
}

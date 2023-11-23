using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Cliente;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Cliente;
using SCRO_Web_API.Models.Data.Dto.PacienteResponsavelDto;
using SCRO_Web_API.Models.Data.Dto.ResponsavelDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;
[ApiController]
[Route("[controller]")]
public class ResponsavelController : Controller
{
    SCROContext _context;
    IMapper _mapper;

    public ResponsavelController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtém um responsavel pelo ID.
    /// </summary>
    /// <param name="id">ID do responsavel.</param>
    /// <returns>O responsavel correspondente ao ID.</returns>
    [HttpGet("/Responsavel/RecuperaResponsavelPorId/{id}")]
    [ProducesResponseType(200, Type = typeof(ReadResponsavelDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> RecuperaResponsavelPorId(int id)
    {
        var responsavel = await _context.Responsaveis.FirstOrDefaultAsync(responsavel => responsavel.ResponsavelId == id);
        if (responsavel == null) return NotFound();
        var responsavelDto = _mapper.Map<ReadResponsavelDto>(responsavel);
        return Ok(responsavelDto);
    }

    /// <summary>
    /// Obtém uma lista de responsaveis.
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados.</param>
    /// <param name="take">Número máximo de registros a serem retornados.</param>
    /// <returns>Uma lista de responsaveis.</returns>
    [HttpGet("/Responsavel/RecuperaResponsaveis")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ReadResponsavelDto>))]
    public async Task<IEnumerable> RecuperaResponsaveis([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var responsaveis = await _context.Responsaveis.Skip(skip).Take(take).ToListAsync();
        var responsaveisDto = _mapper.Map<List<ReadResponsavelDto>>(responsaveis);
        return responsaveisDto;
    }

    /// <summary>
    /// Adiciona um novo responsavel.
    /// </summary>
    /// <param name="responsavelDto">Dados do responsavel a serem adicionados.</param>
    /// <returns>O responsavel recém-adicionado.</returns>
    [HttpPost("/Responsavel/AdicionarResponsavel")]
    [ProducesResponseType(201, Type = typeof(ReadResponsavelDto))]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AdicionarResponsavel(CreateResponsavelDto responsavelDto)
    {
        if (responsavelDto == null) return BadRequest("O objeto responsavelDto não pode ser nulo.");

        try
        {
            var responsavel = _mapper.Map<Responsavel>(responsavelDto);
            await _context.Responsaveis.AddAsync(responsavel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaResponsavelPorId), new { id = responsavel.ResponsavelId }, responsavel);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível inserir este responsavel no sistema, verifique se ele já existe: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }

    }


    /// <summary>
    /// Atualiza os dados de um responsável existente.
    /// </summary>
    /// <param name="id">ID do responsavel a ser atualizado.</param>
    /// <param name="responsavelDto">Dados do responsavel para atualização.</param>
    /// <returns>Código de status OK se a atualização for bem-sucedida.</returns>
    [HttpPut("/Responsavel/AtualizarResponsavel/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AtualizarResponsavel(int id, [FromBody] UpdateResponsavelDto responsavelDto)
    {
        if (responsavelDto == null) return BadRequest("O objeto responsavelDto não pode ser nulo.");

        try
        {
            var responsavel = await _context.Responsaveis.FirstOrDefaultAsync(responsavel => responsavel.ResponsavelId == id);
            if (responsavel == null) return NotFound();
            _mapper.Map(responsavelDto, responsavel);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível atualizar este responsavel no sistema, verifique se ele já existe: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }

    }

    /// <summary>
    /// Deleta um responsavel existente.
    /// </summary>
    /// <param name="id">ID do responsavel a ser excluido.</param>
    /// <returns>Código de status OK se a exclusão for bem-sucedida.</returns>
    [HttpDelete("/Responsavel/ExcluirResponsavel/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ExcluirResponsavel(int id)
    {
        var responsavel = await _context.Responsaveis.FirstOrDefaultAsync(responsavel => responsavel.ResponsavelId == id);
        if (responsavel == null) return NotFound();
        try
        {
            _context.Responsaveis.Remove(responsavel);
            await _context.SaveChangesAsync();
            return Ok();

        }
        catch (DbUpdateException ex)
        {
            return BadRequest($"Não foi possível excluir este responsavel do sistema, responsavel vinculado a um paciente: {ex.Message}, {ex.InnerException}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro inesperado: {ex.Message}");
        }
    }

    /// <summary>
    /// Obtém uma lista de pacientes e responsaveis.
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados.</param>
    /// <param name="take">Número máximo de registros a serem retornados.</param>
    /// <returns>Uma lista de pacientes e responsaveis.</returns>
    [HttpGet("/Responsavel/RecuperaVinculoPacientesResponsaveis")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ReadPacienteResponsavelDto>))]
    public async Task<IEnumerable> RecuperaVinculoPacientesResponsaveis([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var pacientesResponsaveis = await _context.PacientesResponsaveis.Skip(skip).Take(take).ToListAsync();
        var pacientesResponsaveisDto = _mapper.Map<List<ReadPacienteResponsavelDto>>(pacientesResponsaveis);
        return pacientesResponsaveisDto;
    }

    /// <summary>
    /// Obtém a lista de vinculos entre paciente e responsavel pelo ID.
    /// </summary>
    /// <param name="idPaciente">ID do paciente.</param>
    /// <param name="idResponsavel">ID do responsavel.</param>
    /// <returns>A configuração correspondente ao ID.</returns>
    [HttpGet("/Responsavel/RecuperaVinculoPacienteResponsavelPorId/{idPaciente}/{idResponsavel}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ReadPacienteResponsavelDto>))]
    [ProducesResponseType(404)]
    public async Task<IEnumerable> RecuperaVinculoPacienteResponsavelPorId(int idPaciente = 0, int idResponsavel = 0)
    {// ou um ou outro ou os 2 - corrigir (if para validar)
        List<PacienteResponsavel> pacientesResponsaveis = new();
        if (idPaciente > 0 && idResponsavel == 0)
        {
            pacientesResponsaveis = await _context.PacientesResponsaveis.Where(pr => pr.PacienteId == idPaciente).ToListAsync();

        }
        else if (idResponsavel > 0 && idPaciente == 0)
        {
            pacientesResponsaveis = await _context.PacientesResponsaveis.Where(pr => pr.ResponsavelId == idResponsavel).ToListAsync();
        }
        else
        {
            pacientesResponsaveis = await _context.PacientesResponsaveis.Where(pr => pr.PacienteId == idPaciente & pr.ResponsavelId == idResponsavel).ToListAsync();
        }
        var pacientesResponsaveisDto = _mapper.Map<List<ReadPacienteResponsavelDto>>(pacientesResponsaveis);
        return pacientesResponsaveisDto;
    }

    /// <summary>
    /// Adiciona um registro de paciente e responsavel.
    /// </summary>
    /// <param name="pacienteResponsavelDto">Dados do paciente e responsavel a serem adicionados.</param>
    /// <returns>O responsavel recém-adicionado.</returns>
    [HttpPost("/Responsavel/VincularResponsavelPaciente")]
    [ProducesResponseType(201, Type = typeof(ReadResponsavelDto))]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> VincularResponsavelPaciente(CreatePacienteResponsavelDto pacienteResponsavelDto)
    {
        if (pacienteResponsavelDto == null) return BadRequest("PacienteId ou ResponsavelId estão nulos, verifique os valores e tente novamente");

        try
        {
            var pacienteResponsavel = _mapper.Map<PacienteResponsavel>(pacienteResponsavelDto);
            await _context.PacientesResponsaveis.AddAsync(pacienteResponsavel);
            await _context.SaveChangesAsync();
            return Ok(pacienteResponsavel);
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível inserir esta configuração de paciente e responsavel no sistema, verifique se ele já existe: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    /// <summary>
    /// Atualiza os dados de um vinculo paciente e responsável existente.
    /// </summary>
    /// <param name="id">ID do vinculo paciente responsavel a ser atualizado.</param>
    /// <returns>Código de status OK se a atualização for bem-sucedida.</returns>
    [HttpPut("/Responsavel/AtualizarPacienteResponsavel/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AtualizarPacienteResponsavel(int id, [FromBody] UpdatePacienteResponsavelDto pacienteResponsavelDto)
    {
        if (pacienteResponsavelDto == null) return BadRequest("O objeto pacienteResponsavelDto  não pode ser nulo");

        try
        {
            var pacienteResponsavel = await _context.PacientesResponsaveis.FirstOrDefaultAsync(pr => pr.PacienteResponsavelId == id);
            if (pacienteResponsavel == null) return NotFound("Vinculo não encontrado.");
            _mapper.Map(pacienteResponsavelDto, pacienteResponsavel);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível atualizar esta configuração de paciente e responsavel no sistema: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }        
    }

    /// <summary>
    /// Deleta um vinculo entre paciente e responsavel existente.
    /// </summary>
    /// <param name="id">ID do paciente a ser excluido.</param>
    /// <returns>Código de status OK se a exclusão for bem-sucedida.</returns>
    [HttpDelete("/Responsavel/ExcluirVinculoPacienteResponsavel/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ExcluirVinculoPacienteResponsavel(int id)
    {
        var pacienteResponsavel = await _context.PacientesResponsaveis.FirstOrDefaultAsync(pr => pr.PacienteResponsavelId== id);
        if (pacienteResponsavel == null) return NotFound("Vinculo não encontrado.");

        try
        {
            _context.PacientesResponsaveis.Remove(pacienteResponsavel);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível excluir esta configuração de paciente e responsavel no sistema: \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
        
    }
}

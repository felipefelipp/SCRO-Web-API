using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Atendimento;
using SCRO_Web_API.Models.Data.Dto.AtendimentoDto;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AtendimentoController : Controller
{
    SCROContext _context;
    IMapper _mapper;
    public AtendimentoController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("/Atendimento/RecuperaAtendimentoPorId/{id}")]
    public async Task<IActionResult> RecuperaAtendimentoPorId(int id)
    {
        var atendimento = await _context.Atendimentos.FirstOrDefaultAsync(a => a.AtendimentoPacienteId == id);
        if (atendimento == null) return NotFound($"Atendimento com ID {id} não encontrado"); 
        var atendimentoDto = _mapper.Map<ReadAtendimentoDto>(atendimento);
        return Ok(atendimentoDto);
    }

    [HttpGet("/Atendimento/RecuperaAtendimentos")]
    public async Task<IEnumerable<ReadAtendimentoDto>> RecuperaAtendimentos([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var atendimentos = await _context.Atendimentos.Skip(skip).Take(take).ToListAsync();
        var atendimentosDto = _mapper.Map<List<ReadAtendimentoDto>>(atendimentos);
        return atendimentosDto;
    }

    [HttpPost("/Atendimento/AdicionarAtendimento")]
    public async Task<IActionResult> AdicionarAtendimento([FromBody] CreateAtendimentoDto atendimentoDto)
    {
        if (atendimentoDto == null)
        {
            return BadRequest("O objeto atendimentoDro não pode ser nulo.");
        }

        try
        {
            var atendimento = _mapper.Map<AtendimentoPaciente>(atendimentoDto);
            await _context.Atendimentos.AddAsync(atendimento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaAtendimentoPorId), new { id = atendimento.AtendimentoPacienteId }, atendimento);

        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível inserir este atendimento no sistema. \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    [HttpPut("/Atendimento/AtualizarAtendimento/{id}")]
    public async Task<IActionResult> AtualizarAtendimento(int id, [FromBody] UpdateAtendimentoDto atendimentoDto)
    {
        if (atendimentoDto == null)
        {
            return BadRequest("O objeto atendimentoDro não pode ser nulo.");
        }

        try
        {
            var atendimento = await _context.Atendimentos.FirstOrDefaultAsync(a => a.AtendimentoPacienteId == id);
            if(atendimento == null) return NotFound();
            _mapper.Map(atendimentoDto, atendimento);
            return Ok();

        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível atualizar este atendimento no sistema. \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }

    [HttpDelete("/Atendimento/ExcluirAtendimento/{id}")]
    public async Task<IActionResult> ExcluirAtendimento(int id) 
    {
        var atendimento = await _context.Atendimentos.FirstOrDefaultAsync(a => a.AtendimentoPacienteId == id);
        if (atendimento == null) return NotFound();

        try
        {
            _context.Atendimentos.Remove(atendimento);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest("Não foi possível atualizar este atendimento no sistema. \n" + ex.Message + ": \n" + ex.InnerException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro inesperado: " + ex.Message);
        }
    }
}

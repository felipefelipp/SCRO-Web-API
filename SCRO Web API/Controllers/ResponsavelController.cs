using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Cliente;
using Models.Data.Contexto;
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

    [HttpGet("{id}")]
    public IActionResult RecuperaResponsavelPorId(int id)
    {
        var responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.ResponsavelId == id);
        if (responsavel == null) return NotFound();
        var responsavelDto = _mapper.Map<ReadResponsavelDto>(responsavel);
        return Ok(responsavelDto);
    }

    [HttpGet]
    public IEnumerable RecuperaResponsaveis([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var responsaveis = _context.Responsaveis.Skip(skip).Take(take).ToList();
        var responsaveisDto = _mapper.Map<List<ReadResponsavelDto>>(responsaveis);
        return responsaveisDto;
    }

    [HttpPost]
    public IActionResult AdicionaResponsavel(CreateResponsavelDto responsavelDto)
    {
        try
        {
            Responsavel responsavel = _mapper.Map<Responsavel>(responsavelDto);
            _context.Responsaveis.Add(responsavel);
            _context.SaveChanges();
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

    [HttpPut]
    public IActionResult AtualizaResponsavel(int id, [FromBody] UpdateResponsavelDto responsavelDto)
    {

        try
        {
            var responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.ResponsavelId == id);
            if (responsavel == null) return NotFound();
            _mapper.Map(responsavelDto, responsavel);
            _context.SaveChanges();
            return Ok();
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

    [HttpDelete("{id}")]
    public IActionResult RemoveResponsavel(int id)
    {
        var responsavel = _context.Responsaveis.FirstOrDefault(responsavel => responsavel.ResponsavelId == id);
        if (responsavel == null) return NotFound();
        _context.Responsaveis.Remove(responsavel);
        _context.SaveChanges();
        return Ok();
    }
}

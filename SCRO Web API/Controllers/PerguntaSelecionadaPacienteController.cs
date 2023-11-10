using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.PerguntaSelecionadaPacienteDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PerguntaSelecionadaPacienteController : Controller
{
    SCROContext _context;
    IMapper _mapper;
    public PerguntaSelecionadaPacienteController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPerguntaSelecionadaPorId(int id)
    {
        var perguntaSelecionadaPaciente = _context.PerguntaSelecionadaPaciente.FirstOrDefault(rsp => rsp.PerguntaSelecionadaPacienteId == id);
        if (perguntaSelecionadaPaciente == null) { return NotFound(); }
        var perguntaSelecionadaPacienteDto = _mapper.Map<ReadPerguntaSelecionadaPacienteDto>(perguntaSelecionadaPaciente);
        return Ok(perguntaSelecionadaPacienteDto);
    }

    [HttpGet]
    public IEnumerable RecuperaPerguntasSelecionadas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var perguntaSelecionadas = _context.PerguntaSelecionadaPaciente.Skip(skip).Take(take).ToList();
        var perguntasSelecionadasDto = _mapper.Map<List<ReadPerguntaSelecionadaPacienteDto>>(perguntaSelecionadas);
        return perguntasSelecionadasDto;
    }

    [HttpPost]
    public IActionResult AdicionaPerguntaSelecionada(CreatePerguntaSelecionadaPacienteDto perguntaSelecionadaDto)
    {
        var perguntaSelecionadapaciente = _mapper.Map<PerguntaSelecionadaPaciente>(perguntaSelecionadaDto);
        _context.PerguntaSelecionadaPaciente.Add(perguntaSelecionadapaciente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPerguntaSelecionadaPorId), new { id = perguntaSelecionadapaciente.PerguntaSelecionadaPacienteId }, perguntaSelecionadapaciente);
    }

    [HttpPut]
    public IActionResult AtualizaPerguntaSelecionada(int id, UpdatePerguntaSelecionadaPacienteDto perguntaSelecionadaDto)
    {
        var perguntaSelecionadaPaciente = _context.PerguntaSelecionadaPaciente.FirstOrDefault(rsp => rsp.PerguntaSelecionadaPacienteId == id);
        if (perguntaSelecionadaPaciente == null) return NotFound();
        _mapper.Map(perguntaSelecionadaDto, perguntaSelecionadaPaciente);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemovePerguntaSelecionada(int id)
    {
        var perguntaSelecionadaPaciente = _context.PerguntaSelecionadaPaciente.FirstOrDefault(rsp => rsp.PerguntaSelecionadaPacienteId == id);
        if (perguntaSelecionadaPaciente == null) return NotFound();
        _context.PerguntaSelecionadaPaciente.Remove(perguntaSelecionadaPaciente);
        _context.SaveChanges();
        return Ok();
    }
}

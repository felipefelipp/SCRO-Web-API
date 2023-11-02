using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.PerguntaDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PerguntaController : Controller
{
    SCROContext _context;
    IMapper _mapper;
    public PerguntaController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPerguntaPorId(int id)
    {
        var pergunta = _context.Perguntas.FirstOrDefault(pergunta => pergunta.PerguntaId == id);
        if (pergunta == null)  return NotFound();
        var perguntaDto = _mapper.Map<ReadPerguntaDto>(pergunta);
        return Ok(perguntaDto);
    }

    [HttpGet]
    public IEnumerable RecuperaPerguntas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var perguntas = _context.Perguntas.Skip(skip).Take(take).ToList();
        var perguntasDto = _mapper.Map<List<ReadPerguntaDto>>(perguntas);
        return perguntasDto;
    }

    [HttpPost]
    public IActionResult AdicionaPergunta(CreatePerguntaDto perguntaDto)
    {
        Pergunta pergunta = _mapper.Map<Pergunta>(perguntaDto);
        _context.Perguntas.Add(pergunta);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPerguntaPorId), new { id = pergunta.PerguntaId }, pergunta);

    }

    [HttpPut]
    public IActionResult AtualizaPergunta(int id, [FromBody] UpdatePerguntaDto perguntaDto)
    {
        var pergunta = _context.Perguntas.FirstOrDefault(pergunta => pergunta.PerguntaId == id);
        if (pergunta == null) return NotFound();
        _mapper.Map(perguntaDto, pergunta);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemovePergunta(int id)
    {
        var pergunta = _context.Perguntas.FirstOrDefault(pergunta => pergunta.PerguntaId == id);
        if (pergunta == null) return NotFound();
        _context.Remove(pergunta);
        _context.SaveChanges();
        return Ok();
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.RespostaDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class RespostaController : Controller
{
    SCROContext _context;
    IMapper _mapper;

    public RespostaController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaRespostaPorId(int id)
    {
        var resposta = _context.Respostas.FirstOrDefault(resposta => resposta.RespostaId == id);
        if (resposta == null) return NotFound();
        var respostaDto = _mapper.Map<ReadRespostaDto>(resposta);
        return Ok(respostaDto);
    }

    [HttpGet]
    public IEnumerable RecuperaRespostas([FromQuery] int skip = 0,[FromQuery] int take = 5)
    {
        var respostas = _context.Respostas.Skip(skip).Take(take).ToList();
        var respostasDto = _mapper.Map<List<ReadRespostaDto>>(respostas);
        return respostasDto;
    }

    [HttpPost]
    public IActionResult AdicionaResposta(CreateRespostaDto respostaDto)
    {
        var resposta = _mapper.Map<Resposta>(respostaDto);
        _context.Respostas.Add(resposta);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaRespostaPorId), new {id = resposta.RespostaId} ,resposta);
    }

    [HttpPut]
    public IActionResult AtualizaResposta(int id, UpdateRespostaDto respostaDto)
    {
        var resposta = _context.Respostas.FirstOrDefault(resposta => resposta.RespostaId == id);
        if (resposta == null) return NotFound();
        _mapper.Map(respostaDto, resposta);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemoveResposta(int id) 
    {
        var resposta = _context.Respostas.FirstOrDefault(resposta => resposta.RespostaId == id);
        if (resposta == null) return NotFound();
        _context.Respostas.Remove(resposta);
        _context.SaveChanges();
        return Ok();
    }
}

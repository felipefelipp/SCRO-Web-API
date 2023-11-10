using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.RespostaSelecionadaPacienteDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class RespostaSelecionadaPacienteController : Controller
{
    SCROContext _context;
    IMapper _mapper;
    public RespostaSelecionadaPacienteController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaRespostaSelecionadaPorId(int id)
    {
        var respostaSelecionadaPaciente = _context.RespostaSelecionadaPaciente.FirstOrDefault(rsp => rsp.RespostaSelecionadaPacienteId == id);
        if (respostaSelecionadaPaciente == null) { return NotFound(); }
        var respostaSelecionadaPacienteDto = _mapper.Map<ReadRespostaSelecionadaPacienteDto>(respostaSelecionadaPaciente);
        return Ok(respostaSelecionadaPacienteDto);
    }

    [HttpGet]
    public IEnumerable RecuperaRespostasSelecionadas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var respostasSelecionadas = _context.RespostaSelecionadaPaciente.Skip(skip).Take(take).ToList();    
        var respostasSelecionadasDto = _mapper.Map<List<ReadRespostaSelecionadaPacienteDto>>(respostasSelecionadas);
        return respostasSelecionadasDto;
    }

    [HttpPost]
    public IActionResult AdicionaRespostaSelecionada(CreateRespostaSelecionadaPacienteDto respostaSelecionadaDto) 
    {
        RespostaSelecionadaPaciente respostaSelecionadapaciente = _mapper.Map<RespostaSelecionadaPaciente>(respostaSelecionadaDto);
        _context.RespostaSelecionadaPaciente.Add(respostaSelecionadapaciente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaRespostaSelecionadaPorId), new { id = respostaSelecionadapaciente.RespostaSelecionadaPacienteId}, respostaSelecionadapaciente);
    }

    [HttpPut]
    public IActionResult AtualizaRespostaSelecionada(int id, UpdateRespostaSelecionadaPacienteDto respostaSelecionadaDto)
    {
        var respostaSelecionadaPaciente = _context.RespostaSelecionadaPaciente.FirstOrDefault(rsp => rsp.RespostaSelecionadaPacienteId == id);
        if (respostaSelecionadaPaciente  == null) return NotFound();
        _mapper.Map(respostaSelecionadaDto, respostaSelecionadaPaciente);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemoveRespostaSelecionada(int id)
    {
        var respostaSelecionadaPaciente = _context.RespostaSelecionadaPaciente.FirstOrDefault(rsp => rsp.RespostaSelecionadaPacienteId == id);
        if (respostaSelecionadaPaciente == null) return NotFound();
        _context.RespostaSelecionadaPaciente.Remove(respostaSelecionadaPaciente);
        _context.SaveChanges();
        return Ok();
    }

}

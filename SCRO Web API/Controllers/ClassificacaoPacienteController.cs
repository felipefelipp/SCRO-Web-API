using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.CategoriaPerguntaDto;
using SCRO_Web_API.Models.Data.Dto.ClassificacaoPacienteDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;
[ApiController]
[Route("[controller]")]
public class ClassificacaoPacienteController : Controller
{
    SCROContext _context;
    IMapper _mapper;

    public ClassificacaoPacienteController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaClassificacaoPacientePorId(int id)
    {
        var classificacao = _context.Classificacoes.FirstOrDefault(classificacao => classificacao.ClassificacaoPacienteId == id);
        if (classificacao == null) return NotFound();
        var classificacaoDto = _mapper.Map<ReadClassificacaoPacienteDto>(classificacao);
        return Ok(classificacaoDto);
    }

    [HttpGet]
    public IEnumerable RecuperaClassificacoes([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var classificacoes = _context.Classificacoes.Skip(skip).Take(take).ToList();
        var classificacoesDto = _mapper.Map<List<ReadClassificacaoPacienteDto>>(classificacoes);
        return classificacoesDto;
    }

    [HttpPost]
    public IActionResult AdicionaClassificacaoPaciente(CreateClassificacaoPacienteDto classificacaoPacienteDto)
    {
        var classificacao = _mapper.Map<ClassificacaoPaciente>(classificacaoPacienteDto);
        _context.Classificacoes.Add(classificacao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaClassificacaoPacientePorId), new { id = classificacao.ClassificacaoPacienteId }, classificacao);
    }

    [HttpPut]
    public IActionResult AtualizaClassificacaoPaciente(int id, UpdateClassificacaoPacienteDto classificacaoPacienteDto)
    {
        var classificacao = _context.Classificacoes.FirstOrDefault(classificacao => classificacao.ClassificacaoPacienteId == id);
        if (classificacao == null) return NotFound();
        _mapper.Map(classificacaoPacienteDto, classificacao);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemoverClassificacaoPaciente(int id)
    {
        var classificacao = _context.Classificacoes.FirstOrDefault(classificacao => classificacao.ClassificacaoPacienteId == id);
        if (classificacao == null) return NotFound();
        _context.Classificacoes.Remove(classificacao);
        _context.SaveChanges();
        return Ok();
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Data.Dto.CategoriaPerguntaDto;
using System.Collections;

namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaPerguntaController : Controller
{
    SCROContext _context;
    IMapper _mapper;

    public CategoriaPerguntaController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCategoriaPerguntaPorId(int id)
    {
        var categoria = _context.CategoriaPerguntas.FirstOrDefault(categoria => categoria.CategoriaPerguntaId == id);
        if (categoria == null) return NotFound();
        var categoriaDto = _mapper.Map<ReadCategoriaPerguntaDto>(categoria);
        return Ok(categoriaDto);
    }

    [HttpGet]
    public IEnumerable RecuperaCategoriaPerguntas([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var categorias = _context.CategoriaPerguntas.Skip(skip).Take(take).ToList();
        var categoriasDto = _mapper.Map<List<ReadCategoriaPerguntaDto>>(categorias);
        return categoriasDto;
    }

    [HttpPost]
    public IActionResult AdicionaCategoriaPergunta(CreateCategoriaPerguntaDto categoriaPerguntaDto)
    {
        CategoriaPergunta categoriaPergunta = _mapper.Map<CategoriaPergunta>(categoriaPerguntaDto);
        _context.CategoriaPerguntas.Add(categoriaPergunta);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCategoriaPerguntaPorId), new { id = categoriaPergunta.CategoriaPerguntaId }, categoriaPergunta);
    }

    [HttpPut]
    public IActionResult AtualizaCategoriaPergunta(int id, UpdateCategoriaPerguntaDto categoriaPerguntaDto)
    {
        var categoriaPergunta = _context.CategoriaPerguntas.FirstOrDefault(categoriaPergunta => categoriaPergunta.CategoriaPerguntaId == id);
        if (categoriaPergunta == null) return NotFound();
        _mapper.Map(categoriaPerguntaDto, categoriaPergunta);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult RemoverCategoriaPergunta(int id)
    {
        var categoriaPergunta = _context.CategoriaPerguntas.FirstOrDefault(categoriaPergunta => categoriaPergunta.CategoriaPerguntaId == id);
        if (categoriaPergunta == null) return NotFound();
        _context.CategoriaPerguntas.Remove(categoriaPergunta);
        _context.SaveChanges();
        return Ok();
    }
}

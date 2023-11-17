using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Classificacao;
using Models.Data.Contexto;
using SCRO_Web_API.Models.Classificacao;
using SCRO_Web_API.Models.Data.Dto.ResultadoDto;
using System.Collections;
using System.Linq;


namespace SCRO_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultadoController : Controller
{
    SCROContext _context;
    IMapper _mapper;
    public ResultadoController(SCROContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet("{id}")]
    public IActionResult RecuperaResultadoId(int id)
    {
        var resultado = _context.Resultados.FirstOrDefault(r => r.ResultadoId == id);
        if (resultado == null) { return NotFound(); }
        var resultadoDto = _mapper.Map<ReadResultadoDto>(resultado);
        return Ok(resultadoDto);
    }

    [HttpGet]
    public IEnumerable RecuperaResultados([FromQuery] int skip, [FromQuery] int take)
    {
        var resultados = _context.Resultados.Skip(skip).Take(take).ToList();
        var resultadosDto = _mapper.Map<List<ReadResultadoDto>>(resultados);
        return resultadosDto;
    }

    [HttpPost]
    public IActionResult ObterResultado(int ClassificacaoId)
    {

        var resultado = (from cp in _context.Classificacoes
                         join rsp in _context.RespostaSelecionadaPaciente on cp.ClassificacaoPacienteId equals rsp.ClassificacaoPacienteId
                         join r in _context.Respostas on rsp.RespostaId equals r.RespostaId
                         where cp.ClassificacaoPacienteId == ClassificacaoId
                         group r.ValorResposta by new { cp.ClassificacaoPacienteId, cp.PacienteId } into grupo
                         select new
                         {
                             ValorResposta = grupo.Sum(),
                             ClassificacaoPacienteId = grupo.Key.ClassificacaoPacienteId,
                             PacienteId = grupo.Key.PacienteId,
                             ResultadoCor = 0
                         }).FirstOrDefault();



        if (resultado.ClassificacaoPacienteId < 0)
        {
            return NotFound("Classificação não encontrada, tente novamente. ");
        }

        Resultado resultadoClassificacao = new Resultado
        {
            ClassificacaoPacienteId = resultado.ClassificacaoPacienteId,
            PacienteId = resultado.PacienteId,
            ValorResultadoClassificacao = resultado.ValorResposta,
            ResultadoCor = resultado.ResultadoCor
        };

        _context.Resultados.Add(resultadoClassificacao);
        return CreatedAtAction(nameof(RecuperaResultadoId), new { id = resultadoClassificacao.ResultadoId }, resultadoClassificacao);
    }
}

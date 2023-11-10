using Models.Enums;
using Models.Extensions;
using SCRO_Web_API.Models.Data.Dto.Base;

namespace SCRO_Web_API.Models.Data.Dto.ClassificacaoPacienteDto;

public class ReadClassificacaoPacienteDto : ClassificacaoPacienteBaseDto
{
    public int ClassificacaoPacienteId { get; set; }
    public int ResultadoCor { get; set; }
    public string ResultadoClassificacaoCor
    {
        get { return ResultadoCor.ParaValorClassificacao().ToString(); }
    }
}

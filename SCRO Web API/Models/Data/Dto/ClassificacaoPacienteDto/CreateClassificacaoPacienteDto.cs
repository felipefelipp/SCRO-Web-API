using Models.Enums;
using SCRO_Web_API.Models.Data.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace SCRO_Web_API.Models.Data.Dto.ClassificacaoPacienteDto;

public class CreateClassificacaoPacienteDto : ClassificacaoPacienteBaseDto
{
    [RegularExpression("^[12345]$", ErrorMessage = "Valor incorreto, preencha um dos valores: 1 - Vermelho, " +
                                                                                             "2 - Laranja, " +
                                                                                             "3 - Amarelo, " +
                                                                                             "4 - Verde, " +
                                                                                             "5 - Azul")]
    public int ResultadoCor { get; set; }
}

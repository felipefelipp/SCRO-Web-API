using SCRO_Web_API.Models.Data.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace SCRO_Web_API.Models.Data.Dto.RespostaDto;

public class UpdateRespostaDto : RespostaBaseDto
{
    [RegularExpression("^[12345]$", ErrorMessage = "Valor incorreto, preencha um dos valores: 1 - Text, " +
                                                                                            "2 - TextArea, " +
                                                                                            "3 - CheckBox, " +
                                                                                            "4 - ComboBox, " +
                                                                                            "5 - Radiobutton, " +
                                                                                            "6 - Data")]
    public int ValorTipoResposta { get; set; }
}

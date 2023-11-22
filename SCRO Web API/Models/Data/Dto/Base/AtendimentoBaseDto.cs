using Models.Classificacao;

namespace SCRO_Web_API.Models.Data.Dto.Base;

public class AtendimentoBaseDto
{
    public int PacienteId { get; set; }
    public string SenhaClassificacao { get; set; }
    public DateTime DataAtendimento { get; set; }
}

using Models.Classificacao;

namespace SCRO_Web_API.Models.Atendimento;

public class AtendimentoPaciente
{
    public int AtendimentoPacienteId { get; set; }
    public int PacienteId { get; set; }
    public string SenhaClassificacao { get; set; }
    public DateTime DataAtendimento { get; set; }
    public virtual ClassificacaoPaciente ClassificacaoPaciente { get; set; }
}

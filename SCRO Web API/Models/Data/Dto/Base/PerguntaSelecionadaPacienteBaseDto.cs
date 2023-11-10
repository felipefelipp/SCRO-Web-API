namespace SCRO_Web_API.Models.Data.Dto.Base;

public abstract class PerguntaSelecionadaPacienteBaseDto
{
    public int PerguntaId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}

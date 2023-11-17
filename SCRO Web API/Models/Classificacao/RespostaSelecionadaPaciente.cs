namespace Models.Classificacao;

public class RespostaSelecionadaPaciente
{
    public int RespostaSelecionadaPacienteId { get; set; }
    public int PerguntaId { get; set; }
    public int RespostaId { get; set; }
    public string ValorRespostaTexto { get; set; }
    public string ValorRespostaTextoArea { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
}
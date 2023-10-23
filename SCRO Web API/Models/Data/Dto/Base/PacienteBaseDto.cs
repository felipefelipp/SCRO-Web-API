namespace SCRO_Web_API.Models.Data.Dto.Base;

public abstract class PacienteBaseDto
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Rua { get; set; }
    public int? Numero { get; set; }
    public string Bairro { get; set; }
    public string Municipio { get; set; }
    public string UF { get; set; }
    public int? CEP { get; set; }
    public char? Sexo { get; set; }
    public string Profissao { get; set; }
    public string SenhaClassificacao { get; set; }
}

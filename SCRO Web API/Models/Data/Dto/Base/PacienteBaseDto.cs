using System.ComponentModel.DataAnnotations;

namespace SCRO_Web_API.Models.Data.Dto.Base;

public abstract class PacienteBaseDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(250, MinimumLength = 2, ErrorMessage = "O Campo nome deve possuir entre 2 e 250 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data é obrigatório.")]
    [Range(typeof(DateTime), "1900-01-01T00:00:00", "2200-12-31T23:59:59",ErrorMessage ="A data não pode ser inferior a 01/01/1900")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "Verifique o CPF, não pode ter mais de 11 dígitos ou pontuação")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O RG é obrigatório.")]
    [RegularExpression("^[0-9]{8}$", ErrorMessage = "Verifique o RG, ele deve conter 8 dígitos e não possuir pontuação")]
    public string RG { get; set; }

    [Required(ErrorMessage = "O Telefone é obrigatório.")]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "Verifique o Celular, ele deve possuir 10 digitos incluindo ddd e não pode ter pontuação")]
     public string Telefone { get; set; }

    [Required(ErrorMessage = "O Celular é obrigatório.")]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "Verifique o Celular, ele deve possuir 11 digitos incluindo ddd e não pode ter pontuação")]
    public string Celular { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O e-mail não pode ter mais de 250 caracteres")]
    [MinLength(10, ErrorMessage = "O e-mail precisa ter mais de 10 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A rua é obrigatório.")]
    public string Rua { get; set; }

    [Required(ErrorMessage = "O número é obrigatório.")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O municipio é obrigatório.")]
    public string Municipio { get; set; }

    [Required(ErrorMessage = "A UF é obrigatório.")]
    [MaxLength(2, ErrorMessage = "Não pode ser maior que 2 caracteres")]
    public string UF { get; set; }

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    [RegularExpression("^[0-9]{8}$", ErrorMessage = "Verifique o CEP, ele deve possuir 8 dígitos e não ter pontuação")]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O sexo é obrigatório.")]
    [RegularExpression("^[FM]$", ErrorMessage = "Selecione M ou F")]
    public char Sexo { get; set; }

    [Required(ErrorMessage = "A profissão é obrigatório.")]
    [MaxLength(250, ErrorMessage = "Não pode ser maior que 250 caracteres")]
    public string Profissao { get; set; }
}

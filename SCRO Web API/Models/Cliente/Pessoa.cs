namespace Models.Cliente;

public abstract class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    //public Pessoa(string nome,
    //              DateTime dtNascimento,
    //              string cpf,
    //              string rg,
    //              string celular,
    //              string email)
    //{
    //    Nome = nome;
    //    DataNascimento = dtNascimento;
    //    CPF = cpf;
    //    RG = rg;
    //    Celular = celular;
    //    Email = email;
    //}


    //public Pessoa() { }
}

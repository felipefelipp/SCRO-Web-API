namespace Models.Cliente;

public class Paciente : Pessoa
{
    public int PacienteId { get; set; }
    public virtual Responsavel? Responsavel { get; set; }
    public string Telefone { get;  set; }
    public string Rua { get;  set; }
    public int Numero { get;  set; }
    public string Bairro { get;  set; }
    public string Municipio { get;  set; }
    public string UF { get;  set; }
    public int CEP { get;  set; }
    public char Sexo { get;  set; }
    public string Profissao { get;  set; }
    public string SenhaClassificacao { get;  set; }
    //public Paciente(string nome,
    //                DateTime dtNascimento,
    //                string cpf,
    //                string rg,
    //                string celular,
    //                string telefone,
    //                string rua,
    //                int numero,
    //                string bairro,
    //                string municipio,
    //                string uf,
    //                int cep,
    //                char sexo,
    //                string profissao,
    //                string email) : base(nome, dtNascimento, cpf, rg, celular, email)
    //{
    //    Telefone = telefone;
    //    Rua = rua;
    //    Numero = numero;
    //    Bairro = bairro;
    //    Municipio = municipio;
    //    UF = uf;
    //    CEP = cep;
    //    Sexo = sexo;
    //    Profissao = profissao;
    //}

    //public Paciente(Responsavel responsavel,
    //                string nome,
    //                DateTime dtNascimento,
    //                string cpf,
    //                string rg,
    //                string celular,
    //                string telefone,
    //                string rua,
    //                int numero,
    //                string bairro,
    //                string municipio,
    //                string uf,
    //                int cep,
    //                char sexo,
    //                string profissao,
    //                string email) : this(nome, dtNascimento, cpf, rg, celular, telefone, rua, numero, bairro, municipio, uf, cep, sexo, profissao, email)
    //{
    //    Responsavel = responsavel;
    //}

    //public Paciente() { }

}

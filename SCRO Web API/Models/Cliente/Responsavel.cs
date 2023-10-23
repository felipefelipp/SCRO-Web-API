namespace Models.Cliente
{
    public class Responsavel : Pessoa
    {
        public int? ResponsavelId { get;  set; }
        public int? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public Responsavel(string nome, DateTime dtNascimento, string cpf, string rg, string celular, string email) : base(nome, dtNascimento, cpf, rg, celular, email)
        {
        }
        public Responsavel() { }
    }
}

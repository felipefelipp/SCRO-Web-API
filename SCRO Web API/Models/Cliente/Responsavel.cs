namespace Models.Cliente
{
    public class Responsavel : Pessoa
    {
        public int ResponsavelId { get;  set; }
        public virtual IList<Paciente> Paciente { get; set; }
    }
}

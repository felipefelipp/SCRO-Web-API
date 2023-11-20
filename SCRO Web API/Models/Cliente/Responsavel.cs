namespace Models.Cliente
{
    public class Responsavel : Pessoa
    {
        public int ResponsavelId { get;  set; }
        public int? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}

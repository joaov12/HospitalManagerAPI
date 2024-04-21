namespace HospitalManager.Models
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Funcionario>? Funcionarios { get; set; }
    }
}

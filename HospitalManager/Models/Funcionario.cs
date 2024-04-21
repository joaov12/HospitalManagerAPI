using System.ComponentModel.DataAnnotations;

namespace HospitalManager.Models
{
    public class Funcionario
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get; set; }
        public double Salario { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

    }
}

using HospitalManager.Enums;

namespace HospitalManager.Models
{
    public class Medico : Funcionario
    {
        public string Crm { get; set; }
        public EspecialidadeMedico Especialidade { get; set; }
    }
}

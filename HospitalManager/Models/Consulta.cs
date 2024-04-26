using HospitalManager.Enums;

namespace HospitalManager.Models
{
    public class Consulta
    {
        public Guid Id { get; set; }
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Data { get; set; }
        public string MotivoConsulta { get; set; }
        public StatusProcedimento StatusProcedimento { get; set; }

    }
}

using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<Paciente>> BuscarTodosPacientes();
        Task<Paciente> BuscarPorId(Guid id);
        Task<Paciente> Adicionar(Paciente paciente);
        Task<Paciente> Atualizar(Paciente paciente);
        Task<bool> Apagar(Guid id);
    }
}

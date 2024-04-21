using HospitalManager.Models;
namespace HospitalManager.Repositorios.Interfaces
{
    public interface IEnfermeiroRepositorio
    {
        Task<List<Enfermeiro>> BuscarTodosEnfermeiros();
        Task<Enfermeiro> BuscarPorId(Guid id);
        Task<Enfermeiro> Adicionar(Enfermeiro enfermeiro);
        Task<Enfermeiro> Atualizar(Enfermeiro enfermeiro);
        Task<bool> Apagar(Guid id);
    }
}

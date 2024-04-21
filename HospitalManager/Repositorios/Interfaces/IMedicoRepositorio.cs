using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IMedicoRepositorio
    {
        Task<List<Medico>> BuscarTodosMedicos();
        Task<Medico> BuscarPorId(Guid id);
        Task<Medico> Adicionar(Medico medico);
        Task<Medico> Atualizar(Medico medico);
        Task<bool> Apagar(Guid id);

    }
}

using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<Funcionario>> BuscarTodosFuncionarios();
        Task<Funcionario> BuscarPorId(Guid id);
        Task<Funcionario> Adicionar(Funcionario funcionario);
        Task<Funcionario> Atualizar(Funcionario funcionario);
        Task<bool> Apagar(Guid id);
    }
}

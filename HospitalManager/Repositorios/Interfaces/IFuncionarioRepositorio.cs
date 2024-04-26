using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<Funcionario>> BuscarTodosFuncionarios();
        Task<Funcionario> BuscarPorId(Guid id);
    }
}

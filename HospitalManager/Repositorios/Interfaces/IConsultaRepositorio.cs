using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IConsultaRepositorio
    {
        Task<List<Consulta>> BuscarTodasConsultas();
        // Buscar consultas feitas, a fazer, canceladas etc..
        Task<Consulta> BuscarPorId(Guid id);
        Task<Consulta> Adicionar(Consulta consulta);
        Task<Consulta> Atualizar(Consulta consulta);
        Task<bool> Apagar(Guid id);
    }
}

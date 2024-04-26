using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class ConsultaRepositorio : IConsultaRepositorio
    {

        private readonly HospitalManagerDBContext _dbContext;
        public ConsultaRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<bool> Apagar(Guid id)
        {
            Consulta consulta = await BuscarPorId(id);
            if (consulta == null)
            {
                throw new Exception("Não existe consulta com esse ID");
            }

            _dbContext.Consultas.Remove(consulta);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Consulta> Atualizar(Consulta consultaEditada)
        {
            Consulta consulta = _dbContext.Consultas.AsNoTracking().FirstOrDefault(x => x.Id == consultaEditada.Id);

            if(consulta == null)
            {
                throw new Exception("Não existe consulta com esse ID");
            }
            _dbContext.Consultas.Update(consultaEditada);
            await _dbContext.SaveChangesAsync();
            return consultaEditada;
        }

        public async Task<Consulta> Adicionar(Consulta consulta)
        {
            await _dbContext.Consultas.AddAsync(consulta);
            await _dbContext.SaveChangesAsync();
            return consulta;
        }

        public Task<Consulta> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consulta>> BuscarTodasConsultas()
        {
            throw new NotImplementedException();
        }
    }
}

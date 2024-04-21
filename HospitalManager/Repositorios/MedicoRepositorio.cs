using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class MedicoRepositorio : IMedicoRepositorio
    {
        private readonly HospitalManagerDBContext _dbContext;
        public MedicoRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<List<Medico>> BuscarTodosMedicos()
        {
            return await _dbContext.Medicos.ToListAsync();
        }
        public async Task<Medico> BuscarPorId(Guid id)
        {
            return await _dbContext.Medicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Medico> Adicionar(Medico medico)
        {
            await _dbContext.Medicos.AddAsync(medico);
            await _dbContext.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> Atualizar(Medico medicoEditado)
        {
            Medico medico = _dbContext.Medicos.AsNoTracking().FirstOrDefault(x => x.Id == medicoEditado.Id);
            if (medico == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Medicos.Update(medicoEditado);
            await _dbContext.SaveChangesAsync();

            return medicoEditado;

        }
        public async Task<bool> Apagar(Guid id)
        {
            Medico medico = await BuscarPorId(id);
            if (medico == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Medicos.Remove(medico);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

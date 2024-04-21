using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class EnfermeiroRepositorio : IEnfermeiroRepositorio
    {
        private readonly HospitalManagerDBContext _dbContext;
        public EnfermeiroRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<List<Enfermeiro>> BuscarTodosEnfermeiros()
        {
            return await _dbContext.Enfermeiros.Include(d => d.Departamento).ToListAsync();
        }
        public async Task<Enfermeiro> BuscarPorId(Guid id)
        {
            return await _dbContext.Enfermeiros.Include(d => d.Departamento).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Enfermeiro> Adicionar(Enfermeiro enfermeiro)
        {
            await _dbContext.Enfermeiros.AddAsync(enfermeiro);
            await _dbContext.SaveChangesAsync();
            return enfermeiro;
        }

        public async Task<Enfermeiro> Atualizar(Enfermeiro enfermeiroEditado)
        {
            Enfermeiro enfermeiro = _dbContext.Enfermeiros.AsNoTracking().FirstOrDefault(x => x.Id == enfermeiroEditado.Id);
            if (enfermeiro == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Enfermeiros.Update(enfermeiroEditado);
            await _dbContext.SaveChangesAsync();

            return enfermeiroEditado;

        }
        public async Task<bool> Apagar(Guid id)
        {
            Enfermeiro enfermeiro = await BuscarPorId(id);
            if (enfermeiro == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Enfermeiros.Remove(enfermeiro);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

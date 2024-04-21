using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly HospitalManagerDBContext _dbContext;
        public PacienteRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<List<Paciente>> BuscarTodosPacientes()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }
        public async Task<Paciente> BuscarPorId(Guid id)
        {
            return await _dbContext.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Paciente> Adicionar(Paciente paciente)
        {
            await _dbContext.Pacientes.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> Atualizar(Paciente pacienteEditado)
        {
            Paciente paciente = _dbContext.Pacientes.AsNoTracking().FirstOrDefault(x => x.Id == pacienteEditado.Id);
            if (paciente == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Pacientes.Update(pacienteEditado);
            await _dbContext.SaveChangesAsync();

            return pacienteEditado;

        }
        public async Task<bool> Apagar(Guid id)
        {
            Paciente paciente = await BuscarPorId(id);
            if (paciente == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly HospitalManagerDBContext _dbContext;
        public FuncionarioRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<List<Funcionario>> BuscarTodosFuncionarios()
        {
            return await _dbContext.Funcionarios.Include(d => d.Departamento).
                ToListAsync();
        }
        public async Task<Funcionario> BuscarPorId(Guid id)
        {
            return await _dbContext.Funcionarios.Include(d => d.Departamento).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

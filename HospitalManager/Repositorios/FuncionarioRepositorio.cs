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

        public async Task<Funcionario> Adicionar(Funcionario funcionario)
        {
            await _dbContext.Funcionarios.AddAsync(funcionario);
            await _dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> Atualizar(Funcionario funcionarioEditado)
        {
            Funcionario funcionario = _dbContext.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == funcionarioEditado.Id);
            if (funcionario == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Funcionarios.Update(funcionarioEditado);
            await _dbContext.SaveChangesAsync();

            return funcionarioEditado;

        }
        public async Task<bool> Apagar(Guid id)
        {
            Funcionario funcionario = await BuscarPorId(id);
            if (funcionario == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Funcionarios.Remove(funcionario);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

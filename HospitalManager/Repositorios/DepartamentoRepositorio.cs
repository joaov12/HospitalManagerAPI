using HospitalManager.Data;
using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Repositorios
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly HospitalManagerDBContext _dbContext;
        public DepartamentoRepositorio(HospitalManagerDBContext hospitalManagerDBContext)
        {
            _dbContext = hospitalManagerDBContext;
        }

        public async Task<List<Departamento>> BuscarTodosDepartamentos()
        {
             return await _dbContext.Departamentos
        .Include(d => d.Funcionarios) // Carrega os funcionários relacionados
        .ToListAsync();
        }
        public async Task<Departamento> BuscarPorId(Guid id)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Departamento> Adicionar(Departamento departamento)
        {
            await _dbContext.Departamentos.AddAsync(departamento);
            await _dbContext.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> Atualizar(Departamento departamentoEditado)
        {
            Departamento departamento = _dbContext.Departamentos.AsNoTracking().FirstOrDefault(x => x.Id == departamentoEditado.Id);
            if (departamento == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Departamentos.Update(departamentoEditado);
            await _dbContext.SaveChangesAsync();

            return departamentoEditado;

        }
        public async Task<bool> Apagar(Guid id)
        {
            Departamento departamento = await BuscarPorId(id);
            if (departamento == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            _dbContext.Departamentos.Remove(departamento);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Departamento> AdicionarFuncionarioAoDepartamento(Guid departamentoId, Guid funcionarioId)
        {
            var departamento = await _dbContext.Departamentos
                .Include(d => d.Funcionarios)
                .FirstOrDefaultAsync(d => d.Id == departamentoId);

            if (departamento == null)
            {
                throw new Exception("Departamento não encontrado");
            }

            var funcionario = await _dbContext.Funcionarios.FindAsync(funcionarioId);

            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado");
            }

            departamento.Funcionarios.Add(funcionario);
            await _dbContext.SaveChangesAsync();
            return departamento;
        }

        
    }
}

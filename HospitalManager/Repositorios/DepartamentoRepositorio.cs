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
            return await _dbContext.Departamentos.ToListAsync();
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

        public async Task<Departamento> AdicionarMedicoDepartamento(Guid id, Medico medico)
        {

            Departamento departamento = await BuscarPorId(id);
            if (medico.Id == null)
            {
                throw new Exception("Usuario nao encontrado");
            }
            if (departamento.Funcionarios == null)
            {
                departamento.Funcionarios = new List<Funcionario>(); // Initialize Funcionarios if null
            }
            departamento.Funcionarios.Add((Funcionario)medico);
            await _dbContext.SaveChangesAsync();
            return departamento;
            
        }

    }
}

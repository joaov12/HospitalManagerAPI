﻿using HospitalManager.Models;

namespace HospitalManager.Repositorios.Interfaces
{
    public interface IDepartamentoRepositorio
    {
        Task<List<Departamento>> BuscarTodosDepartamentos();
        Task<Departamento> BuscarPorId(Guid id);
        Task<Departamento> Adicionar(Departamento departamento);
        Task<Departamento> Atualizar(Departamento departamento);
        Task<Departamento> AdicionarFuncionarioAoDepartamento(Guid departamentoId, Guid funcionarioId);
        Task<bool> Apagar(Guid id);
    }
}

using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        public DepartamentoController(IDepartamentoRepositorio departamentoRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return Ok(await _departamentoRepositorio.BuscarTodosDepartamentos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamentoById(Guid id)
        {
            Departamento departamento = await _departamentoRepositorio.BuscarPorId(id);

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> CreateDepartamento(Departamento departamento)
        {
            return Ok(await _departamentoRepositorio.Adicionar(departamento));
        }

        [HttpPut]
        public async Task<ActionResult<Departamento>> UpdateDepartamento(Departamento departamento)
        {
            departamento = await _departamentoRepositorio.Atualizar(departamento);
            return Ok(departamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveDepartamento(Guid id)
        {
            bool departamento = await _departamentoRepositorio.Apagar(id);
            return Ok(departamento);
        }

        [HttpPut("AdicionaMedicoDepto")]
        public async Task<ActionResult<Departamento>> AdicionaMedicoDepartamento(Guid id, Medico medico)
        {
            Departamento departamento = await _departamentoRepositorio.AdicionarMedicoDepartamento(id, medico);

            return departamento;
        }
    }
}

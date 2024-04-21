using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> GetPacientes()
        {
            return Ok(await _pacienteRepositorio.BuscarTodosPacientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteById(Guid id)
        {
            Paciente paciente = await _pacienteRepositorio.BuscarPorId(id);

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> CreatePaciente(Paciente paciente)
        {
            return Ok(await _pacienteRepositorio.Adicionar(paciente));
        }

        [HttpPut]
        public async Task<ActionResult<Paciente>> UpdatePaciente(Paciente paciente)
        {
            paciente = await _pacienteRepositorio.Atualizar(paciente);
            return Ok(paciente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemovePaciente(Guid id)
        {
            bool paciente = await _pacienteRepositorio.Apagar(id);
            return Ok(paciente);
        }
    }
}

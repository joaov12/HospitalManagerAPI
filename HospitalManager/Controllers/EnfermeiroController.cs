using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermeiroController : ControllerBase
    {
        private readonly IEnfermeiroRepositorio _enfermeiroRepositorio;
        public EnfermeiroController(IEnfermeiroRepositorio enfermeiroRepositorio)
        {
            _enfermeiroRepositorio = enfermeiroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Enfermeiro>>> GetEnfermeiros()
        {
            return Ok(await _enfermeiroRepositorio.BuscarTodosEnfermeiros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermeiro>> GetEnfermeiroById(Guid id)
        {
            Enfermeiro enfermeiro = await _enfermeiroRepositorio.BuscarPorId(id);

            return Ok(enfermeiro);
        }

        [HttpPost]
        public async Task<ActionResult<Enfermeiro>> CreateEnfermeiro(Enfermeiro enfermeiro)
        {
            return Ok(await _enfermeiroRepositorio.Adicionar(enfermeiro));
        }

        [HttpPut]
        public async Task<ActionResult<Enfermeiro>> UpdateEnfermeiro(Enfermeiro enfermeiro)
        {
             enfermeiro = await _enfermeiroRepositorio.Atualizar(enfermeiro);
            return Ok(enfermeiro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveEnfermeiro(Guid id)
        {
            bool enfermeiro = await _enfermeiroRepositorio.Apagar(id);
            return Ok(enfermeiro);
        }
    }
}

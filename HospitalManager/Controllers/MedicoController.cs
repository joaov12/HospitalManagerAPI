using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        public MedicoController(IMedicoRepositorio medicoRepositorio)
        {
            _medicoRepositorio = medicoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medico>>> GetMedicos()
        {
            return Ok(await _medicoRepositorio.BuscarTodosMedicos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedicoById(Guid id)
        {
            Medico medico = await _medicoRepositorio.BuscarPorId(id);

            return Ok(medico);
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> CreateMedico(Medico medico)
        {
            return Ok(await _medicoRepositorio.Adicionar(medico));
        }

        [HttpPut]
        public async Task<ActionResult<Medico>> UpdateMedico(Medico medico)
        {
             medico = await _medicoRepositorio.Atualizar(medico);
            return Ok(medico);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveMedico(Guid id)
        {
            bool medico = await _medicoRepositorio.Apagar(id);
            return Ok(medico);
        }
    }
}

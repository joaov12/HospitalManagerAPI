using HospitalManager.Models;
using HospitalManager.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> GetFuncionarios()
        {
            return Ok(await _funcionarioRepositorio.BuscarTodosFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionarioById(Guid id)
        {
            Funcionario funcionario = await _funcionarioRepositorio.BuscarPorId(id);

            return Ok(funcionario);
        }
    }
}

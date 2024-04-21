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

        [HttpPost]
        public async Task<ActionResult<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
            return Ok(await _funcionarioRepositorio.Adicionar(funcionario));
        }

        [HttpPut]
        public async Task<ActionResult<Funcionario>> UpdateFuncionario(Funcionario funcionario)
        {
             funcionario = await _funcionarioRepositorio.Atualizar(funcionario);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveFuncionario(Guid id)
        {
            bool funcionario = await _funcionarioRepositorio.Apagar(id);
            return Ok(funcionario);
        }
    }
}

using CrudMongoDb.Models;
using CrudMongoDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudMongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly CrudMongoDbService _crudService;

        public PessoaController(CrudMongoDbService crudService)
        {
            _crudService = crudService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPessoa(string id)
        {
            var pessoa = _crudService.ObterPessoa(id);
            return Ok(pessoa);
        }

        [HttpGet]
        public IActionResult ListarPessoas()
        {
            var pessoas = _crudService.ListarPessoas();
            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult IncluirPessoa([FromBody] Pessoa pessoa)
        {
            _crudService.IncluirPessoa(pessoa);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarPessoa(string id, [FromBody] Pessoa pessoa)
        {
            _crudService.AlterarPessoa(id, pessoa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirPessoa(string id)
        {
            _crudService.ExcluirPessoa(id);
            return Ok();
        }
    }
}

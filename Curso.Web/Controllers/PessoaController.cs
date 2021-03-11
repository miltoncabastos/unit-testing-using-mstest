using Microsoft.AspNetCore.Mvc;
using Repository.Pessoas;

namespace Curso.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _pessoaRepository.ObterTodasPessoas();
            return Ok(pessoas);
        }
    }
}
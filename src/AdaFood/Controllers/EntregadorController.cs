using AdaFood.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadorController : ControllerBase
    {
        private readonly IEntregadorRepository _repository;

        public EntregadorController (IEntregadorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("adicionarEntregador")]
        public IActionResult AddEntregador([FromBody] EntregadorRequest entregadorRequest)
        {
            _repository.Add(entregadorRequest);
            return Created();
        }

        [HttpGet("buscarEntregador/{CPF}")]
        public IActionResult Get(string CPF)
        {
            return Ok(_repository.GetByCPF(CPF));
        }

    }
}

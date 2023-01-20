using ApiEstoque.Domain.Models;
using ApiEstoque.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstoque.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController()
        {
            _service = new ClienteService();
        }

        [HttpGet("cliente")]
        public IActionResult Listar([FromQuery] string? nome)
        {
            return StatusCode(200, _service.Listar(nome));
        }

        [HttpGet("cliente/{cpfCliente}")]
        public IActionResult Obter([FromRoute] string cpfCliente)
        {
            return StatusCode(200, _service.Obter(cpfCliente));
        }

        [HttpPost("cliente")]
        public IActionResult Inserir([FromBody] Cliente model)
        {
            _service.Inserir(model);
            return StatusCode(201);
        }

        [HttpDelete("cliente/{cpfCliente}")]
        public IActionResult Deletar([FromRoute] string cpfCliente)
        {
            _service.Deletar(cpfCliente);
            return StatusCode(200);
        }

        [HttpPut("cliente")]
        public IActionResult Atualizar([FromBody] Cliente model)
        {
            _service.Atualizar(model);
            return StatusCode(201);
        }
    }
}

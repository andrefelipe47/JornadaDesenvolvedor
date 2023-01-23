using ApiSuperMercado.Domain.Exceptions;
using ApiSuperMercado.Domain.Models;
using ApiSuperMercado.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSuperMercado.Controllers
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
        public IActionResult Obter([FromRoute] string cpfCliente, [FromHeader] string acc)
        {
            return StatusCode(200, _service.Obter(cpfCliente));
        }

        [HttpPost("cliente")]
        public IActionResult Inserir([FromBody] Cliente model)
        {
            try
            {
                _service.Inserir(model);
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
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
            try
            {
                _service.Atualizar(model);
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}

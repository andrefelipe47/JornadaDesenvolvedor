using ApiSupermecado.Domain.Exceptions;
using ApiSupermecado.Domain.Models;
using ApiSupermecado.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiSupermecado.Controllers
{
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet("cliente")]
        public IActionResult Listar([FromQuery] string? nome)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var login = identity.FindFirst("login").Value;

            return StatusCode(200, _service.Listar(nome));
        }

        [HttpGet("cliente/{cpfCliente}")]
        public IActionResult Obter([FromRoute] string cpfCliente)
        {
            return StatusCode(200, _service.Obter(cpfCliente));
        }

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
        [HttpDelete("cliente/{cpfCliente}")]
        public IActionResult Deletar([FromRoute] string cpfCliente)
        {
            _service.Deletar(cpfCliente);
            return StatusCode(200);
        }

        [Authorize(Roles = "1")]
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

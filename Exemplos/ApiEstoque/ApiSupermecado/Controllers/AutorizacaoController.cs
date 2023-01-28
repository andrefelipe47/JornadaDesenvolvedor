using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiSupermecado.Domain.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using ApiSupermecado.Services;

namespace ApiSupermecado.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly AutorizacaoService _service;
        public AutorizacaoController(AutorizacaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Metodo para autenticar no sistema
        /// Campos obrigatórios: email, senha
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna um bearer token de 12 horas com nivel de acesso e nome do usuário</returns>
        [ProducesResponseType(typeof(Token), 200)]
        [ProducesResponseType(401)]
        [HttpPost("Autorizacao")]
        public IActionResult Login(Usuario model)
        {
            try
            {
                var token = _service.Login(model);
                return StatusCode(200, token);
            }
            catch (Exception)
            {
                return StatusCode(401);
            }
        }
    }
}

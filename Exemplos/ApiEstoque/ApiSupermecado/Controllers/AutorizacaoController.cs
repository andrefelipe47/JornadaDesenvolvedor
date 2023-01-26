using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiSupermecado.Domain.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace ApiSupermecado.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AutorizacaoController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost("Autorizacao")]
        public IActionResult Login(Usuario model)
        {
            if (model.Login == "string" && model.Senha == "string")
            {
                var senhaJwt = Encoding.ASCII.GetBytes
                (_config["SenhaJwt"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("login", model.Login),
                       new Claim(ClaimTypes.Role, EnumPermissaoUsuario.User.GetHashCode().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(senhaJwt),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);

                return StatusCode(200, new
                {
                    Token = stringToken,
                    Validade = tokenDescriptor.Expires
                });
            }
            else
            {
                return StatusCode(401);
            }
        }
    }
}

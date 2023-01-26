using ApiSuperMercado.Domain.Exceptions;
using ApiSuperMercado.Domain.Models;
using ApiSuperMercado.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSuperMercado.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet("produto")]
        public IActionResult Listar([FromQuery] string? nome)
        {
            return StatusCode(200, _service.Listar(nome));
        }

        [HttpGet("produto/{identificadorProduto}")]
        public IActionResult Obter([FromRoute] int identificadorProduto)
        {
            return StatusCode(200, _service.Obter(identificadorProduto));
        }

        [HttpPost("produto")]
        public IActionResult Inserir([FromBody] Produto model)
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

        [HttpDelete("produto/{identificadorProduto}")]
        public IActionResult Deletar([FromRoute] int identificadorProduto)
        {
            _service.Deletar(identificadorProduto);
            return StatusCode(200);
        }

        [HttpPut("produto")]
        public IActionResult Atualizar([FromBody] Produto model)
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

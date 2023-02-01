using CloudMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudMarket.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;
        private readonly RelatorioService _relatorioService;
        public ClienteController(
            ClienteService service,
            RelatorioService relatorioService
            )
        {
            _service = service;
            _relatorioService = relatorioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string? nome)
        {
            return StatusCode(200, _service.Listar(nome));
        }

        [HttpPost("cliente")]
        public IActionResult Inserir([FromBody] Domain.Models.Cliente model)
        {
            _service.Inserir(model);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Relatorio()
        {
            return File(_relatorioService.GerarRelatorioCliente(), contentType: "text/csv", fileDownloadName: "relatorio.csv", enableRangeProcessing: true);
        }
        public IActionResult Novo()
        {
            return View();
        }
    }
}

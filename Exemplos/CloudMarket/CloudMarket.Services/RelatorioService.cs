using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMarket.Services
{
    public class RelatorioService
    {
        private readonly ClienteService _clienteService;
        public RelatorioService(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public Stream GerarRelatorioCliente()
        {
            var clientes = _clienteService.Listar(null);

            string conteudoCsv = "Cpf;Nome;Nascimento;Telefone" + Environment.NewLine;

            foreach (var cliente in clientes)
            {
                conteudoCsv += string.Format("{0};{1};{2};{3};{4}"
                    , cliente.CpfCliente
                    , cliente.Nome
                    , cliente.Nascimento
                    , cliente.Telefone
                    , Environment.NewLine);
            }

            return GenerateStreamFromString(conteudoCsv);
        }
        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

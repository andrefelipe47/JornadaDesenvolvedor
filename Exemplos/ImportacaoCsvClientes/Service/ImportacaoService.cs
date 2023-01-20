using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoCsvClientes.Service
{
    internal class ImportacaoService
    {
        private readonly List<Models.Cliente> _clientes = new List<Models.Cliente>();
        private readonly Gateway.ApiEstoqueGW _gwApiEstoque;
        public ImportacaoService()
        {
            _gwApiEstoque = new Gateway.ApiEstoqueGW();
        }
        public void ImportarClientes()
        {
            LerCsv();
            GravarClientes();
        }

        private void LerCsv()
        {
            var sr = new StreamReader("C:\\Projetos\\DatabasesLocais\\clientes.csv");

            while (!sr.EndOfStream)
            {
                var linha = sr.ReadLine();

                // se linha está nula ou contem um cabecalho, pula para o proximo registro
                if (linha is null || linha.Contains("CpfCliente,Nome,Nascimento,Telefone"))
                    continue;

                ConverterLinhaParaModel(linha);
            }
        }
        private void ConverterLinhaParaModel(string linha)
        {
            var cliente = new Models.Cliente();

            var colunas = linha.Split(',');

            cliente.CpfCliente = colunas[0];
            cliente.Nome = colunas[1];
            cliente.Nascimento = DateTime.ParseExact(colunas[2], "yyyy-MM-dd", null);
            cliente.Telefone = string.IsNullOrWhiteSpace(colunas[3]) ? null : colunas[3];

            _clientes.Add(cliente);
        }
        private void GravarClientes()
        {
            foreach (var cliente in _clientes)
            {
                var clienteBuscado = _gwApiEstoque.Buscar(cliente.CpfCliente);
                if (clienteBuscado is null)
                    _gwApiEstoque.Inserir(cliente);
            }
        }
    }
}

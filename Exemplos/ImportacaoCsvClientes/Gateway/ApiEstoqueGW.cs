using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoCsvClientes.Gateway
{
    internal class ApiEstoqueGW
    {
        public void Inserir(Models.Cliente model)
        {
            var httpClient = new HttpClient();

            var conteudoSerializado = JsonConvert.SerializeObject(model);
            var content = new StringContent(conteudoSerializado, Encoding.UTF8, "application/json");

            var resultado = httpClient.PostAsync("https://localhost:44349/cliente", content).Result;

            string conteudoRetornoApi = resultado.Content.ReadAsStringAsync().Result;

            if (!resultado.IsSuccessStatusCode)
                throw new Exception("Ocorreu um erro ao chamar a api: " + conteudoRetornoApi);
        }

        public Models.Cliente? Buscar(string cpfCliente)
        {
            var httpClient = new HttpClient();

            string urlPesquisa = "https://localhost:44349/cliente/" + cpfCliente;
            var resultado = httpClient.GetAsync(urlPesquisa).Result;

            string conteudoRetornoApi = resultado.Content.ReadAsStringAsync().Result;

            if (!resultado.IsSuccessStatusCode)
                throw new Exception("Ocorreu um erro ao chamar a api: " + conteudoRetornoApi);

            if (resultado.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            return JsonConvert.DeserializeObject<Models.Cliente>(conteudoRetornoApi);
        }
    }
}

using HtmlAgilityPack;
using System.Text;
using System.Xml.Linq;

namespace Robozin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var urlBase = "";
            var client = new HttpClient();
            var result = client.GetAsync("").Result;

            Utf8EncodingProvider.Register();
            var html = result.Content.ReadAsStringAsync().Result;

            // peguei o html e obtive o total de produtos da pagina
            // fingi que fiz calculo, pegando o total de produtos da pagina e fazendo um calculo.
            var totalPagina = 286;

            var paginas = Enumerable.Range(1, totalPagina);

            foreach (var pagina in paginas)
            {
                result = client.GetAsync("").Result;
                html = result.Content.ReadAsStringAsync().Result;

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                //selecionei os produtos pela classe css card-item
                var produtos = doc.DocumentNode.SelectNodes("//div[contains(@class, 'card-item')]");

                foreach (var produto in produtos)
                {
                    var elementoPreco = produto.SelectNodes(".//span[contains(@class, 'align-price')]");
                    if (elementoPreco is null)
                        continue;

                    var preco = elementoPreco[0].InnerText.Replace("R$ ", "").Replace(",", ".");
                    var elementoA = produto.Descendants("a").First();
                    var linkProduto = elementoA.Attributes["href"].Value;
                    var linkCompleto = urlBase + linkProduto.Replace("./", "/");
                    var titulo = produto.SelectNodes(".//div[contains(@class, 'title')]").First().InnerText.Replace("\"", "");
                }
            }
        }
    }

    public class Utf8EncodingProvider : EncodingProvider
    {
        public override Encoding GetEncoding(string name)
        {
            return name == "utf8" ? Encoding.UTF8 : null;
        }

        public override Encoding GetEncoding(int codepage)
        {
            return null;
        }

        public static void Register()
        {
            Encoding.RegisterProvider(new Utf8EncodingProvider());
        }
    }
}
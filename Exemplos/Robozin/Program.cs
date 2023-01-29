using HtmlAgilityPack;
using System.Text;
using System.Xml.Linq;

namespace Robozin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var result = client.GetAsync("https://www.lojagrimorium.com.br/?view=ecom/itens&tcg=1").Result;

            Utf8EncodingProvider.Register();
            var content = result.Content.ReadAsStringAsync().Result;

            var doc = new HtmlDocument();
            doc.LoadHtml(content);
            var cards = doc.DocumentNode.SelectNodes("//div[contains(@class, 'card-item')]").ToArray();

            foreach (var card in cards)
            {
                var link = card.SelectSingleNode(".//a[@href]");
                HtmlAttribute att = link.Attributes["href"];
                var url = att.Value;
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
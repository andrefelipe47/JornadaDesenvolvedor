namespace Exercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quantos tipos de produtos você deseja calcular o lucro:");
            int quantidadeProdutos = Convert.ToInt32(Console.ReadLine());

            string?[] nomesProdutos = new string?[quantidadeProdutos];
            decimal[] lucros = new decimal[quantidadeProdutos];

            // coletando as informações
            for (int i = 0; i < quantidadeProdutos; i++)
            {
                Console.Clear();
                Console.WriteLine("Qual o nome do tipo de produto?");
                nomesProdutos[i] = Console.ReadLine();

                Console.WriteLine("Quantas unidades foram vendidas?");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Qual o preco de compra?");
                decimal precoCompra = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Qual o preco de venda?");
                decimal precoVenda = Convert.ToDecimal(Console.ReadLine());

                lucros[i] = (precoVenda - precoCompra) * quantidade;
            }

            Console.Clear();

            Console.WriteLine("Cada tipo de produto obteve o lucro:" + Environment.NewLine);
            // imprimindo os tipos de produto com o lucro
            for (int i = 0; i < quantidadeProdutos; i++)
            {
                Console.WriteLine("Produto: " + nomesProdutos[i] + " teve um lucro de: R$ " + lucros[i]);
            }
        }
    }
}
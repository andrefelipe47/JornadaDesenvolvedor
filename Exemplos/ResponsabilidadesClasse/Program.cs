namespace ResponsabilidadesClasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Repositorios.ProdutoRepositorio().ProximoIdentificador());
        }
    }
}
namespace LerGravarCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fluxo = new Fluxo();
            var linhaEncontrada = fluxo.ConsultarLinha("Gabriel;Testes");
            var pessoaEncontrada = fluxo.ConsultarPorNomePrimeiroResultado("Luis");
        }
    }
}
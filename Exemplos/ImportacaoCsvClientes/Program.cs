namespace ImportacaoCsvClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var importacaoService = new Service.ImportacaoService();
            importacaoService.ImportarClientes();
        }
    }
}
namespace ManipularArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // objetivo e movimentar o arquivo da pasta de saida para entrada
            // então armazenei as váriaveis com os caminhos completos contendo o nome dos arquivos
            string caminhoEntrada = $"C:{Path.DirectorySeparatorChar}Projetos{Path.DirectorySeparatorChar}Entradas{Path.DirectorySeparatorChar}Sample.txt";
            string caminhoSaida = $"C:{Path.DirectorySeparatorChar}Projetos{Path.DirectorySeparatorChar}Saidas{Path.DirectorySeparatorChar}Sample.txt";

            //se arquivo existe na pasta de entrada
            // para nao impedir a movimentacao
            if (File.Exists(caminhoEntrada))
                File.Delete(caminhoEntrada); // eu deleto antes da pasta de entra do arquivo do caminho

            //Move o arquivo da pasta saidas para a entradas
            File.Move(caminhoSaida, caminhoEntrada);
        }
    }
}
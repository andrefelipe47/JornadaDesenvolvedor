namespace ComoGravarArquivoTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter($"C:{Path.DirectorySeparatorChar}Projetos{Path.DirectorySeparatorChar}Saidas{Path.DirectorySeparatorChar}Sample.txt");
                sw.WriteLine("Hello World!!");
                sw.WriteLine("From the StreamWriter class");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
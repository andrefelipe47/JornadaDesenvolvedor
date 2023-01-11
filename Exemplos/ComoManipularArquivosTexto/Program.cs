namespace ComoLerArquivoTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader($"C:{Path.DirectorySeparatorChar}Projetos{Path.DirectorySeparatorChar}Entradas{Path.DirectorySeparatorChar}Sample.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
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
namespace ManipulandoDatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Data (String) para DateTime
            // converter texto (data americana) para datetime
            var data = DateTime.Parse("2021-01-30");

            // data americana em string com horas para datetime
            var dataComHora = DateTime.Parse("2021-01-30 12:00:00");

            // aqui estamos convertendo usando uma mascara brasileira
            // muito util para nao ter problemas de data errada ou gerar erros
            var dataBrasileira = "01/05/2022";
            var dataDois = DateTime.ParseExact(dataBrasileira, "dd/MM/yyyy", null);
            #endregion

            #region DateTime para String
            Console.WriteLine(dataDois.ToString("dd/MM/yyyy"));
            Console.WriteLine(dataDois.ToString("yyyy-MM-dd"));

            Console.WriteLine($"Em {dataComHora.ToString("dd/MM/yyyy")} as {dataComHora.ToString("HH:mm")} ocorreu uma surpresa");
            #endregion
        }
    }
}
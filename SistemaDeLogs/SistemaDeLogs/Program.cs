using System;

namespace SistemaDeLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            string dataArquivo = dt.ToString("dd-MM-yyyy");
            string nomeArquivo = "mika_log-" + dataArquivo + ".txt";

            GravarLog GL = new GravarLog(@"C:\Mika_log\", nomeArquivo);
            GL.Gravar();

            Console.WriteLine(nomeArquivo);

            Console.ReadLine();
        }
    }
}

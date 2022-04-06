using System;
using System.IO;

namespace SistemaDeLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime dt = DateTime.Now;

            //string dataArquivo = dt.ToString("dd-MM-yyyy");
            //string nomeArquivo = "mika_log-" + dataArquivo + ".txt";

            //GravarLog GL = new GravarLog(@"C:\Mika_log\", nomeArquivo);
            //GL.Gravar();

            //Console.WriteLine(nomeArquivo);

            //Console.ReadLine();


            string anoMesDia = $"{DateTime.Now.ToString("yyyyMMdd_HH-mm")}";
            string DirDestino = @"C:\ARQUIVOSYMF\";
            DirectoryInfo Destino = new DirectoryInfo(DirDestino);

            string DirOrigem = @"E:\TesteArquivo\PLMCC01.txt";
            string Arquivo = "PLMCC01.txt";

            if (!File.Exists(DirDestino + Arquivo))
                File.Move(DirOrigem, DirDestino + Arquivo);
            else
            {
                string movBackup = DirDestino + "Arquivos\\";

                if (!Directory.Exists(movBackup))
                    Directory.CreateDirectory(movBackup);

                if(!Directory.Exists(movBackup + DateTime.Now.Year.ToString()))
                    Directory.CreateDirectory(movBackup + DateTime.Now.Year.ToString());

                movBackup = movBackup + DateTime.Now.ToString("yyyy") + "\\";

                if(!Directory.Exists(movBackup + DateTime.Now.ToString("MM")))
                {
                    Directory.CreateDirectory(movBackup + DateTime.Now.ToString("MM") + "\\");
                    movBackup = movBackup + DateTime.Now.ToString("MM") + "\\";
                    File.Move(DirDestino + Arquivo, movBackup + $"PLMC01_{anoMesDia}.txt");
                }
                else
                {
                    movBackup = movBackup + DateTime.Now.ToString("MM") + "\\";
                    File.Move(DirDestino + Arquivo, movBackup + $"PLMC01_{anoMesDia}.txt");
                }

                if (File.Exists(DirOrigem))
                    File.Move(DirOrigem, DirDestino + Arquivo);

            }



        }
    }
}

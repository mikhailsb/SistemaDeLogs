using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaDeLogs
{
    public class GravarLog
    {
        public string EnderecoArquivo { get; private set; }
        public string NomeArquivo { get; private set; }
        public GravarLog(string caminhoLog, string nomeArq)
        {
            EnderecoArquivo = caminhoLog;
            NomeArquivo = nomeArq;
        }

        public void Gravar()
        {
            if(DirectoryInfo(EnderecoArquivo))
            {
                Console.WriteLine("Diretório criado com sucesso.");
                File.Create(EnderecoArquivo + NomeArquivo);
            }

        }

        private bool DirectoryInfo(string enderecoArquivo)
        {
            DirectoryInfo di = new DirectoryInfo(enderecoArquivo);
            if (!di.Exists)
            {
                di.Create();
                return true;
            }
            else
                return false;

        }
    }
}

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
            if(!File.Exists(EnderecoArquivo+NomeArquivo))
            {

                Console.WriteLine("Não existe");
            }
        }

    }
}

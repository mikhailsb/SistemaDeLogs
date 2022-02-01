using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTE_SANT
{
    public class Banco
    {
        private SqlConnection Conexao;
        public Banco()
        {
            try
            {
                Conexao = new SqlConnection("Server=localhost; User ID=BANCO_SANT; Database=SANT; Password=TESTE1234");
                Conexao.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao realizar a consulta no caixa online. \n " + e.Message);
            }
        }

        public void Dispose()
        {
            if (Conexao.State == System.Data.ConnectionState.Open)
                Conexao.Close();
        }

        public SqlDataReader RetornaComando(string strComando)
        {
            var vComando = new SqlCommand(strComando, Conexao);

            return vComando.ExecuteReader();
        }
    }
}

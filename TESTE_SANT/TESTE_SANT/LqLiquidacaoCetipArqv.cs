using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTE_SANT
{
    public class LqLiquidacaoCetipArqv
    {
        public int COD_ATIVO_MNEMONICO { get; set; }
        public string TIPO_IF { get; set; }
        public string FUNDO_CONTA { get; set; }
        public string FUNDO_CNPJ { get; set; }
        public DateTime DT_INCLUSAO { get; set; }


        public List<LqLiquidacaoCetipArqv> PesquisaCetipArqv()
        {
            Banco banco = new Banco();
            var lqLiquidacao = new List<LqLiquidacaoCetipArqv>();
            try
            {
                var teste = banco.RetornaComando("SELECT * FROM S3_LQ_LIQUIDACAO_CETIP_ARQV");

                while (teste.Read())
                {
                    var tempArqvCetip = new LqLiquidacaoCetipArqv()
                    {
                        COD_ATIVO_MNEMONICO = int.Parse(teste["COD_ATIVO_MNEMONICO"].ToString()),
                        TIPO_IF = teste["TIPO_IF"].ToString(),
                        FUNDO_CONTA = teste["FUNDO_CONTA"].ToString(),
                        FUNDO_CNPJ = teste["FUNDO_CNPJ"].ToString(),
                        DT_INCLUSAO = DateTime.Parse(teste["DT_INCLUSAO"].ToString())
                    };

                    lqLiquidacao.Add(tempArqvCetip);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler conteúdo do banco. \n " + ex.Message);
            }
            return lqLiquidacao;
        }
    }
}

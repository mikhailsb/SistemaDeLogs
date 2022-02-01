using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace TESTE_SANT
{
    class Program
    {
        static void Main(string[] args)
        {
            ArquivoExcel arquivo = null;

            string nomeArquivo = @"E:\TesteArquivo\arquivo.xltx";
            string nomePlanilha = "Planilha1";

            try
            {
                arquivo = new ArquivoExcel(nomeArquivo, nomePlanilha);
                arquivo.ConverterCSV();
            }
            finally
            {
                arquivo = null;

                // Libera objetos da memória e não mais em uso até este ponto
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }

            //Dts.TaskResult = (int)ScriptResults.Success;

            //Excel.Application app = new Excel.Application();
            //Excel.Workbook wbWorkBook = app.Workbooks.Add(vAbreArq);

            //wbWorkBook = app.Workbooks.Open(vAbreArq);
            //Excel.Sheets wsSheet = wbWorkBook.Worksheets;
            //Excel.Worksheet CurSheet = (Excel.Worksheet)wsSheet[1];
            //Excel.Range thisCell = (Excel.Range)CurSheet.Cells[1, 1];

            //thisCell.Value2 = "This is a test.";

            //wbWorkBook.SaveAs(@"E:\TesteArquivo\one.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //wbWorkBook.SaveAs(@"E:\TesteArquivo\two.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //try
            //{

            //    //
            //    var xls = new XLWorkbook(@"E:\TesteArquivo\arquivo.xltx");
            //    var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");
            //    var totalLinhas = planilha.Rows().Count();
            //    // primeira linha é o cabecalho
            //    for (int l = 2; l <= totalLinhas; l++)
            //    {
            //        string codigo = planilha.Cell($"A{l}").Value.ToString();
            //        string descricao = planilha.Cell($"B{l}").Value.ToString();
            //        string preco = planilha.Cell($"C{l}").Value.ToString();
            //        string CNPJ = planilha.Cell($"D{l}").Value.ToString();
            //        string data = planilha.Cell($"E{l}").Value.ToString();
            //        xls.SaveAs(@"E:\TesteArquivo\arquivo.csv");

            //        Console.WriteLine($"{codigo} - {descricao} - {preco}");
            //    }

            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Erro " + ex.Message);
            //}
            Console.ReadLine();
        }
    }
}

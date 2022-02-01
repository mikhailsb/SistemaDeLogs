using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace TESTE_SANT
{
    public class ArquivoExcel
    {
        private Application _app;
        private Workbooks _books;
        private Workbook _book;
        private Sheets _sheets;
        private Worksheet _sheet;

        public ArquivoExcel(
            string arquivo,
            string nomePlanilhaMovimentacao)
        {
            try
            {
                // Gera uma instância do Excel
                _app = new Application();

                if (_book == null)
                {
                    _books = _app.Workbooks;
                    _book = _books.Open(arquivo,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    _sheets = _book.Worksheets;
                    _sheet = (Worksheet)_sheets[1];
                    _sheet.Name = nomePlanilhaMovimentacao;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public void EliminarLinha(int numeroLinha)
        {
            Range range = _sheet.get_Range(
                String.Format("A{0}:A{0}",
                numeroLinha.ToString()),
                Type.Missing);
            range.EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
            ReleaseComObject(range);
            range = null;
        }

        public void ConverterCSV()
        {
            // Fecha a edição do arquivo Excel
            _book.SaveAs(@"cetip.csv", XlFileFormat.xlCSVWindows, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            _book.Close(false, Type.Missing, Type.Missing);
            LiberarProcessoExcel();
        }

        public void Dispose()
        {
            LiberarProcessoExcel();
        }

        private void LiberarProcessoExcel()
        {
            // Libera objetos relativos ao arquivo que
            // está sendo manipulado
            ReleaseComObject(_sheet);
            _sheet = null;

            ReleaseComObject(_sheets);
            _sheets = null;

            ReleaseComObject(_book);
            _book = null;

            ReleaseComObject(_books);
            _books = null;

            // Encerra a instância do Excel
            _app.Quit();
            ReleaseComObject(_app);
            _app = null;
        }

        private void ReleaseComObject(object o)
        {
            // Liberar instância do Interop
            if (o != null)
                System.Runtime.InteropServices
                    .Marshal.ReleaseComObject(o);
        }
    }
}

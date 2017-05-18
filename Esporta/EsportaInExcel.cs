using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Collections;

namespace Esporta
{
    public class EsportaInExcel
    {
        private Microsoft.Office.Interop.Excel.Application _excelApp;// = new Microsoft.Office.Interop.Excel.Application();
        private Microsoft.Office.Interop.Excel.Workbook _workBook;// = new Microsoft.Office.Interop.Excel.Workbook();
        private object _m = Type.Missing;

        public EsportaInExcel()
        {
            _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _workBook = _excelApp.Workbooks.Add(_m);
            //_workBook.Sheets.Delete();
        }

        public void SaveObjectListAsExcel<T>(Hashtable ldata)
        {
            foreach (DictionaryEntry i in ldata) {
                Worksheet ws = _workBook.ActiveSheet as Worksheet;
                ws = _workBook.Sheets.Add(_m, _m, 1, _m) as Worksheet;
                ws = BuildEXCEL(ConvertToDataTable<T>((List<T>)i.Value), (string)i.Key);
            }

            SaveExcelWorkBook();
        }

        public void SaveObjectAsExcel<T>(IList<T> data, string NomeTab)
        {
            _excelApp.Interactive = false;
            _excelApp.Visible = false;
            Worksheet ws;// = new Worksheet();
            ws = BuildEXCEL(ConvertToDataTable<T>(data), NomeTab);
            SaveExcelWorkBook();
        }

        private string SaveExcelWorkBook()
        {
            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.InitialDirectory = @"C:\Attivometro.xlsx";
            openDlg.ShowDialog();
            string path = openDlg.FileName;
            try
            {
                _workBook.SaveAs(path,_m, _m, _m, _m, _m, XlSaveAsAccessMode.xlExclusive, _m, _m, _m, _m, _m);
            }
            catch (Exception ex)
            {
            }
            return path;
        }

        private Microsoft.Office.Interop.Excel.Worksheet BuildEXCEL(System.Data.DataTable tbl, string NomeTab) {
            try
            {
                Worksheet workSheet = _excelApp.ActiveSheet as Worksheet;
                workSheet.Name = NomeTab;
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }
                return workSheet;    
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }

        }

        public System.Data.DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace ExcelLib
{
    public class ExcelDocument : IDisposable
    {
        public Excel.Application? app = null;
        public Excel.Workbooks? books = null;
        public Excel.Workbook? book = null;
        public Excel.Sheets? sheets = null;
        public Excel.Worksheet? sheet = null;
        public Excel.Range? range = null;

        public ExcelDocument()
        {
            app = new Excel.Application();
            books = app.Workbooks;
            book = books.Add();
            sheets = book.Sheets;
        }
        public Excel.Worksheet AddSheet(string sheetName)
        {
            Excel.Worksheet sheet = (Excel.Worksheet)sheets.Add(After: sheets[sheets.Count]);
            sheet.Name = sheetName;
            return sheet;
        }
        public ExcelDocument(string Filename)
        {
            app = new Excel.Application();
        }

       
        public void SaveAs(string Filename)
        {
            book.SaveAs(Filename);
        }

        public void Dispose()
        {
            book.Close();
            app.Quit();
            Release(app);
            Release(books);
            Release(book);
            Release(sheets);
            Release(sheet);
            Release(range);
        }

        public void Release(object obj)
        {
            if (obj != null)
            {
                _ = Marshal.FinalReleaseComObject(obj);
                obj = null;
            }
        }
    }
}
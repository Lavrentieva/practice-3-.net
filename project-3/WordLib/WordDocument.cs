using System;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace WordLib
{
    public class WordDocument : IDisposable
    {
        public Word.Application app = null;
        public Word.Documents docs = null;
        public Word.Document doc = null;

        public WordDocument()
        {
            app = new Word.Application();
            docs = app.Documents;
            doc = docs.Add();
        }

        public void AddTable(string title, List<string[]> rows)
        {
            Word.Paragraph para = doc.Paragraphs.Add();
            para.Range.Text = title;
            para.Range.InsertParagraphAfter();

            Word.Table table = doc.Tables.Add(para.Range, rows.Count, rows[0].Length);
            table.Borders.Enable = 1;

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    table.Cell(i + 1, j + 1).Range.Text = rows[i][j];
                }
            }
        }

        public void SaveAs(string Filename)
        {
            doc.SaveAs2(Filename);
        }

        public void Dispose()
        {
            doc.Close(false, Type.Missing, Type.Missing);
            app.Quit();
            Release(app);
            Release(docs);
            Release(doc);
        }

        public void Release(object obj)
        {
            if (obj != null)
            {
                Marshal.FinalReleaseComObject(obj);
                obj = null;
            }
        }
    }
}
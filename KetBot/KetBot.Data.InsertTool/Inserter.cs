using Microsoft.Azure.Documents.Client;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.InsertTool
{
    public class Inserter
    {
        private string Excelfilename = null;
        private DocumentDbManager dbManager;
        public Inserter(string filename)
        {
            this.Excelfilename = filename;
            try
            {
                this.dbManager = new DocumentDbManager();
            }
            catch(Exception e)
            {
                throw new InvalidOperationException("DocumentDB Init Error.", e);
            }
        }

        public void Start()
        {
            FileInfo dataFile = new FileInfo(Excelfilename);
            using (ExcelPackage pck = new ExcelPackage(dataFile))
            {
                var ws = pck.Workbook.Worksheets["AnswerDB"];

                for(var i=2; i <ws.Dimension.Rows; i++)
                {
                    Console.WriteLine(ws.Cells[i,1].Text);

                    var item = new Data.KetBotDocument();
                    item.id = ws.Cells[i, 1].Text;
                    item.intent = ws.Cells[i, 2].Text.Trim();
                    item.title = ws.Cells[i, 3].Text;
                    item.keywords = ws.Cells[i, 4].Text.Split(',').ToArray<string>();
                    item.answer = ws.Cells[i, 6].Text;
                    var isattachment = string.IsNullOrEmpty(ws.Cells[i, 7].Text);
                    if (isattachment)

                }
                
            }
        }

        private void GenerateDocument()
        {

        }


    }
}

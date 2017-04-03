using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.InsertTool
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string excelFilename = "170331_KetBot_UI_Rule_Structure_WSS_v06.xlsx";
            Inserter inserter = new Inserter(excelFilename);

            inserter.Start();

            Console.ReadLine();
        }
    }
}

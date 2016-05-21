using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComTest;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var docs =Path.GetTempPath();
            var fileName =Path.Combine(docs,"andreiIgnat.xlsx");
            if(File.Exists(fileName))
                File.Delete(fileName);
            var x = new ExcelTest();
           
            //x.CreateNew(fileName);
            //x.CreateCorrect(fileName);
            x.CreateNewDisposable(fileName);
            x = null;
            Console.WriteLine("See if excel it is in task manager");
            Console.ReadKey();
        }
    }
}

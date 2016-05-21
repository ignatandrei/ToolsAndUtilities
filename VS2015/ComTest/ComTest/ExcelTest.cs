using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ComTest
{
    public class ExcelTest
    {
        public void CreateNew(string fileName)
        {

            var a=new Application();
            var w = a.Workbooks.Add();
            w.SaveAs(fileName);
            w.Close();
            a.Quit();
            w = null;
            a = null;
        }

        public void CreateCorrect(string fileName)
        {

            var a = new Application();
            var ws = a.Workbooks;
            var w = ws.Add();
            w.SaveAs(fileName);
            w.Close();
            Marshal.ReleaseComObject(w);
            w = null;
            Marshal.ReleaseComObject(ws);
            ws = null;
            a.Quit();
            Marshal.ReleaseComObject(a);            
            a = null;
        }
    }
}

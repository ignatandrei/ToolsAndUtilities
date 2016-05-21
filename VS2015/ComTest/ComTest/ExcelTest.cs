using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ComDoneRight;
using Microsoft.Office.Interop.Excel;

namespace ComTest
{
    public class ExcelTest
    {
        public void CreateNew(string fileName)
        {

            var a=new Application();
            var w = a.Workbooks.Add(Type.Missing);
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
            var w = ws.Add(null);
            
            
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
        public void CreateNewDisposable(string fileName)
        {

            
            using (dynamic a = new ComDisposable(new Application()))
            {

                using (dynamic ws = a.Workbooks)
                {
                   
                    using (dynamic w = ws.Add())
                    {
                        
                        using (var shs = w.Sheets)
                        {
                            using (var s = shs[1])
                            {
                                //Worksheet a;
                                using (var r = a.Range("A1"))
                                {
                                    r.Value2 = "http://ignatandrei.github.io/ToolsAndUtilities/";
                                    using (var f = r.Font)
                                    {
                                        f.Bold = true;
                                    }
                                }
                                
                            }
                                
                            
                        }
                        w.SaveAs(fileName);
                        w.Close();
                    }
                }
                a.Quit();
               
            }
            
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HtmlAgility
{
    class Program
    {
        static void Main(string[] args)
        {
            #region loading web page
            string html = "";
            var request = WebRequest.Create("http://testmvc4.serviciipeweb.ro/Home/VeryLongDocument");
            var response = request.GetResponse();
            using (var data = response.GetResponseStream())
            {
                using (var sr = new StreamReader(data))
                {
                    html = sr.ReadToEnd();
                }
            }
            #endregion

            #region parsing web page
            var doc=new HtmlDocument();
            doc.LoadHtml(html);
            #endregion

            #region loading nodes
            //http://www.w3schools.com/xpath/xpath_syntax.asp
            foreach (var item in doc.DocumentNode.SelectNodes("//tr/td"))
            {
                
                Console.WriteLine(item.InnerText.Trim());
            }
            #endregion

            Console.ReadKey();
        }
    }
}

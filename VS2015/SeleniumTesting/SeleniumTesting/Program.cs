using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting
{
    class Program
    {
        /// <summary>
        /// https://github.com/SeleniumHQ/selenium
        /// http://www.seleniumhq.org/download/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IWebDriver w=new ChromeDriver();
            
            var nav=w.Navigate();
            nav.GoToUrl("http://msprogrammer.serviciipeweb.ro/about/");
            var source = w.PageSource;
            var str = w.Url;
            Console.WriteLine(str);
            w.FindElement(By.ClassName("page-item-1892")).Click();
            str = w.Url;
            Console.WriteLine(str);

        }
    }
}

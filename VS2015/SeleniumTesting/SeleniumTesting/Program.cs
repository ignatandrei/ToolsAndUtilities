using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
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
            IWebDriver driver=new ChromeDriver();
            
            var nav= driver.Navigate();
            nav.GoToUrl("http://msprogrammer.serviciipeweb.ro/about/");
            var source = driver.PageSource;
            var str = driver.Url;
            Console.WriteLine(str);
            driver.FindElement(By.ClassName("page-item-1892")).Click();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("a.jpg",ImageFormat.Jpeg);
            Process.Start("a.jpg");
            str = driver.Url;
            Console.WriteLine(str);
            driver.Quit();
        }
    }
}

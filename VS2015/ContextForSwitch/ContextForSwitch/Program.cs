using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingSwitch;

namespace ContextForSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            SetLicence();
            var ocr = new GetOCR();
            Console.WriteLine(ocr.OCRFromImage(null));
        }

        static void SetLicence()
        {
            AppContext.SetSwitch("OCR", true);
        }
    }
}

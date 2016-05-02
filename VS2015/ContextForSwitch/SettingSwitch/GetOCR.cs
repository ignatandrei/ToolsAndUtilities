using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingSwitch
{
    
    public class GetOCR
    {
        public bool IsOCREnabled()
        {
            bool test;
            if (!AppContext.TryGetSwitch("OCR", out test))
                return false;

            return test;
        }

        public string OCRFromImage(byte[] image)
        {
            if (!IsOCREnabled())
            {
                throw new LicenseException(this.GetType(), "you do not have licence for OCR");
            }

            return "http://msprogrammer.serviciipeweb.ro/";
        }
    }
}

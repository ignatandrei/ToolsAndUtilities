using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryptObjects;

namespace CryptDOS
{
    class Program
    {
        static void Main(string[] args)
        {
            string Data = "http://bit.ly/Net5Minutes";

            var c =
                CryptUtilitiesSimple.Encrypt(Data);

            Console.WriteLine(c);
            Console.WriteLine(CryptUtilitiesSimple.Decrypt(c));

            int secondsLife = 5;
            Console.WriteLine("decrypt with duration in seconds:" + secondsLife);
            
            c = CryptUtilitiesSimple.EncryptDuration(Data, secondsLife);
            Console.WriteLine(CryptUtilitiesSimple.DecryptDuration(c));

            Thread.Sleep((secondsLife + 1)*1000);

            Console.WriteLine(" Is Decrypted null:" + (CryptUtilitiesSimple.DecryptDuration(c) == null));

        }
    }
}

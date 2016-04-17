using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZipNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //More details at http://www.codeproject.com/Articles/381661/Creating-Zip-Files-Easily-in-NET 
            const string archiveName = "AndreiIgnat.zip";
            if(File.Exists(archiveName))
                File.Delete(archiveName);

            var currentExe = Assembly.GetExecutingAssembly().Location;
            Console.WriteLine(currentExe);
            using (var z = ZipFile.Open(archiveName, ZipArchiveMode.Create))
            {
                z.CreateEntryFromFile(@"Info.txt", "Info.txt", CompressionLevel.Optimal);
                z.CreateEntryFromFile(currentExe,Path.GetFileName(currentExe),CompressionLevel.Optimal);
            }
            Console.Read();

        }
    }
}

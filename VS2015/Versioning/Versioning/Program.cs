using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Versioning
{
    /// <summary>    
    /// read also:
    /// http://semver.org/
    /// https://docs.nuget.org/create/versioning 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            var aiv = GetAttribute<AssemblyInformationalVersionAttribute>();
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            
            if (v != null)
            {
                Console.Write(v.ToString() + " ");
            }
            if (aiv != null)
            {
                Console.WriteLine(aiv.InformationalVersion);
            }


        }

        static T GetAttribute<T>()
            where T:class
        {
            return Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T)).FirstOrDefault() as T;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new Model1())
            {
                Console.WriteLine(context.Department.Count());
                context.Department.Add(new Department() {NameDepartment = "IT"});
                context.SaveChanges();

            }
            using (var context = new Model1())
            {
                Console.WriteLine(context.Department.Count());
            }
        }
    }
}

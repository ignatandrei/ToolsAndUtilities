using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreDll.Models;
using VMBLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
/// <summary>
/// http://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/
/// https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
/// </summary>
namespace TestEmpDep
{
    [TestClass]
    public class InsertEmployeeFacts
    {
        [TestMethod]
        public async Task MaxEmployeesThrowError()
        {
            await Assert.ThrowsExceptionAsync<NotSupportedException>(
                async () => await InsertEmployees(6)
                );

        }
        [TestMethod]
        public async Task InsertEmployeesDoesThrowError()
        {
            
            await InsertEmployees(5);
            Assert.IsTrue(true);

        }

        async Task InsertEmployees(int number)
        {

            var services = new ServiceCollection();

            services.AddDbContext<EmpContext>(options =>
              options.UseInMemoryDatabase("MyDB"));
            services.AddSingleton<VMEmployeeCommand>();
            services.AddSingleton<VMDepartmentCommand>();

            var bsp = services.BuildServiceProvider();

            Department d = new Department();
            d.Name = "IT";
            var depCmd = bsp.GetService<VMDepartmentCommand>();
            var idDepartment = await depCmd.InsertDepartment(d);
            var empCmd = bsp.GetService<VMEmployeeCommand>();


            List<Task> listCommands = new List<Task>();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("number: " + (i + 1));
                Debug.WriteLine("number: " + (i + 1));
                Employee e = new Employee();
                e.Iddepartment = idDepartment;
                e.Name = "Andrei " + i;
                listCommands.Add(empCmd.InsertEmployee(e));
            }
            await Task.WhenAll(listCommands.ToArray());
            var db = bsp.GetService<EmpContext>();
            db.Database.EnsureDeleted();
        }
    }
}

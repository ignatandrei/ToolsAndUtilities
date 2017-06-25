using EFCoreDll.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VMBLL
{

    public class VMEmployeeCommand
    {
        static SemaphoreSlim ss;
        static VMEmployeeCommand()
        {
            ss= new SemaphoreSlim(1,1);
        }
        private EmpContext context;
        public VMEmployeeCommand(EmpContext context)
        {
            
            this.context = context;
        }
        public async Task<int> InsertEmployee(Employee e)
        {
            VMDepartmentQuery query = new VMDepartmentQuery(context);
            await ss.WaitAsync();
            try
            {
                const int nrMaxEmp = 5;
                int nrEmps = await query.NumberEmployees(e.Iddepartment) ;
                
                if (nrEmps >= nrMaxEmp )
                    throw new NotSupportedException("department have more that ${nrMaxEmp} employees");

                context.Employee.Add(e);
                return await context.SaveChangesAsync();
            }
            finally
            {
                ss.Release();
            }

        }
        
    }
}

using EFCoreDll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace VMBLL
{
    public class VMDepartmentCommand
    {
        private EmpContext context;
        public VMDepartmentCommand(EmpContext context)
        {
            this.context = context;
        }
        
        public async Task<int> InsertDepartment(Department d)
        {
            context.Department.Add(d);
            await context.SaveChangesAsync();
            return d.Id;
               
        }
    }
}

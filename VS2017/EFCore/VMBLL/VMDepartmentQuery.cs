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
    public class VMDepartmentQuery
    {
        private EmpContext context;
        public VMDepartmentQuery(EmpContext context)
        {
            this.context = context;
        }
        
        public async Task<int> NumberEmployees(int idDepartment)
        {
            return await context.Employee.Where(d => d.Iddepartment == idDepartment).CountAsync();
               
        }
    }
}

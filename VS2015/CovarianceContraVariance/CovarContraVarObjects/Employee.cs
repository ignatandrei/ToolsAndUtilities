using System;

namespace CovarContraVarObjects
{
    public class Employee:Person
    {
        public Employee()
        {
            this.Name = "Employee Name";
        }
        public string EmployeeID { get; set; }
        
    }
}
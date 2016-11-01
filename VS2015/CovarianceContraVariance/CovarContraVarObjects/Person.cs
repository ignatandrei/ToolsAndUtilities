using System;

namespace CovarContraVarObjects
{
    public class Person
    {
        public Person()
        {
            this.Name = "person name";
        }
        public string  Name { get; protected set; }
    }
}

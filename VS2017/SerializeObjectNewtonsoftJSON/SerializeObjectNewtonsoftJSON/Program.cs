using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace SerializeObjectNewtonsoftJSON
{
    public class Person
    {
        public Person(string namexx)
        {
            Name = namexx;
            
        }
        public string Name { get; set; }
        public object Years { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var p1 = new Person("Andrei Ignat");
            p1.Years = 47;
            var ser = JsonConvert.SerializeObject(p1);
            var p2 = JsonConvert.DeserializeObject<Person>(ser);
            Debug.Assert(p1.Name == p2.Name);
            int i1 = (int)p1.Years;
            int i2 = (int)p2.Years;
            Debug.Assert(i1 == i2);
        }
    }
}

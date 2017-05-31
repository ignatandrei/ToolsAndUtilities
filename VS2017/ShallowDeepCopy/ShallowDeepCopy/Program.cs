using System;

namespace ShallowDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.FirstName = "Andrei";            
            p.Blog.URL= "http://msprogrammer.serviciipeweb.ro/";

            Person deep = p.DeepClone();
            deep.FirstName = "Ignat";
            deep.Blog.URL = "http://serviciipeweb.ro/iafblog/";
            Console.WriteLine("deep clone");
            Console.WriteLine($"{deep.FirstName} {p.FirstName}");
            Console.WriteLine($"{deep.Blog.URL} {p.Blog.URL}");

            Console.WriteLine("member clone");
            Person clone = p.MemberClone();
            clone.FirstName = "Ignat";
            clone.Blog.URL = "http://serviciipeweb.ro/iafblog/";
            Console.WriteLine($"{clone.FirstName} {p.FirstName}");
            Console.WriteLine($"{clone.Blog.URL} {p.Blog.URL}");


        }
    }
}
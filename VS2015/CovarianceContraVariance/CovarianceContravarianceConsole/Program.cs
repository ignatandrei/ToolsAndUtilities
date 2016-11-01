using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovarContraVarObjects;

namespace CovarianceContravarianceConsole
{
    /// <summary>
    /// https://blogs.msdn.microsoft.com/csharpfaq/2010/02/16/covariance-and-contravariance-faq/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //covariance
            IEnumerable < Employee > e= new Employee[] { new Employee()};
            IEnumerable<Person> p = e;
            foreach (var person in p)
            {
                Console.WriteLine(person.Name);
            }

            ISayCovariance<Employee> mE=new MyHelloCovariance<Employee>(new Employee());
            ISayCovariance<Person> mP = mE;
            mP.SayHello();

            //contravariance
            Action<Person> empAction = (pers) => { Console.WriteLine(pers.Name); };
            Action<Employee> persAction = empAction;
            persAction(new Employee());


            ISayContravariance<Person> mSayContravariance=new MySayContravariance<Person>();
            ISayContravariance<Employee> mEmpContravariance = mSayContravariance;
            mEmpContravariance.SayToThis(new Employee());

        }
        
    }
    #region covariance
    interface ISayCovariance<out T>
        where T:Person
    {
        T SayHello( );
    }
    class MyHelloCovariance<T> : ISayCovariance<T>
        where T:Person 
    {
        public MyHelloCovariance(T t)
        {
            this.MyPerson = t;
        }

        public T MyPerson { get; set; }

        public T SayHello()
        {
            Console.WriteLine("hello from MyHelloCovariance" + MyPerson.Name);
            return MyPerson;
        }
    }
    #endregion

    #region contravariance

    interface ISayContravariance<in T>
        where T:Person
    {
        void SayToThis(T t);
    }

    class MySayContravariance< T> : ISayContravariance<T>
        where T:Person
    {
        public void SayToThis(T t)
        {
            Console.WriteLine("Contravariance to "+ t.Name);
        }
    }
    #endregion
}

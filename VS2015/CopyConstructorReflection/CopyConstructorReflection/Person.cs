using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyConstructorReflection
{
    public class Person
    {
        public string Name { get; set; }
        public string WebSite { get; set; }

        public Person():this(null)
        {
            
        }
        /// <summary>
        /// copy constructor for properties
        /// https://en.wikipedia.org/wiki/Copy_constructor_(C%2B%2B)
        /// </summary>
        /// <param name="p"></param>
        public Person(Person p)
        {
            if(p == null)
                return;
            //copy properties
            //this.Name = p.Name;
            //this.WebSite = p.WebSite;
            var props = this.GetType().GetProperties();
            foreach (var propertyInfo in props)
            {
                if(!propertyInfo.CanWrite)
                    continue;
                if(!propertyInfo.CanRead)
                    continue;

                var value = propertyInfo.GetGetMethod().Invoke(p, null);
                propertyInfo.GetSetMethod().Invoke(this, new object[1] {value});

            }


        }
    }
}

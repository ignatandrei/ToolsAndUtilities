using Newtonsoft.Json;

namespace ShallowDeepCopy
{
    class Person
    {
        public Person()
        {
            //initialize for deep clone
            this.Blog = new Blog();
        }
        public string FirstName { get; set; }
        public Blog Blog { get; set; }
        public Person MemberClone()
        {
            return this.MemberwiseClone() as Person;
        }

        public Person DeepClone()
        {
            var set = new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Person>(json,set);
        }
    }
}
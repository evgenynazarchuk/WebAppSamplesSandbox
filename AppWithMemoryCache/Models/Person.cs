using System;

namespace AppWithMemoryCache
{
    public class Person
    {
        public Guid Id { get; set; }
        public String FullName { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }
    }
}

using System;

namespace AutoMapperAutofac.DataContracts
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public DateTime DateOfBirth{ get; set; }
        public AbstractClass AbstractClass { get; set; }
        public string Code { get; set; }

        public Person()
        {
            this.Address = new Address();
        }
    }
}
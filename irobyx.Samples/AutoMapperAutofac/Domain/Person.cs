using System;

namespace AutoMapperAutofac.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AbstractClass AbstractClass { get; set; }
        public SpecialCode SpecialCode { get; set; }

        public Person()
        {
            this.Address = new Address();
            this.SpecialCode = new SpecialCode();
        }
    }
}
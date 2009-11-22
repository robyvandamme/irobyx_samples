using AutoMapperAutofac.Domain;
using AutoMapperAutofac.ObjectMappers;
using ConcreteClass=AutoMapperAutofac.Domain.ConcreteClass;
using Person=AutoMapperAutofac.Domain.Person;

namespace AutoMapperAutofac.ServiceLayer
{
    public class PersonService : IPersonService
    {
        private readonly IDomainMapper<Person, DataContracts.Person> _personMapper;

        public PersonService(IDomainMapper<Person, DataContracts.Person> personMapper)
        {
            _personMapper = personMapper;
        }

        public DataContracts.Person GetPerson()
        {
            var domain = new Person { Name = "Scully" };
            domain.Address.Street = "58th Street";
            // now we need to map it
            var dataContract = _personMapper.Map(domain);
            return dataContract;
        }

        public DataContracts.Person GetDataContractsAbstractPerson()
        {
            var domain = new Person { Name = "Scully" };
            domain.Address.Street = "58th Street";
            var concrete = new ConcreteClass();
            concrete.Number = 1;
            domain.AbstractClass = concrete;
            domain.SpecialCode = new SpecialCode();
            domain.SpecialCode.Code = "special";
            //now we need to map it
            var dataContract = _personMapper.Map(domain);
            return dataContract;
        }

        public Person GetDomainAbstractPerson()
        {
            var dataContract = new DataContracts.Person { Name = "Scully" };
            dataContract.Address.Street = "58th Street";
            var concrete = new OtherConcreteClass();
            concrete.Description = "description";
            dataContract.AbstractClass = concrete;
            // now we need to map it
            var domain = _personMapper.Map(dataContract);
            return domain;
        }
    }
}
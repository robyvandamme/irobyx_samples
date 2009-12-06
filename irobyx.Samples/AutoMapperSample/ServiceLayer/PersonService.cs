using irobyx.AutoMapperSample.Mappers;

namespace irobyx.AutoMapperSample.ServiceLayer
{
    public class PersonService : IPersonService
    {
        private readonly IDomainMapper<Domain.Person, DataContracts.Person> _personMapper;

        public PersonService(IDomainMapper<Domain.Person, DataContracts.Person> personMapper)
        {
            _personMapper = personMapper;
        }

        public DataContracts.Person GetDataContractsAbstractPerson()
        {
            var domain = new Domain.Person { Name = "Scully" };
            domain.Address.Street = "58th Street";
            var concrete = new Domain.ConcreteClass();
            concrete.Number = 1;
            domain.AbstractClass = concrete;
            domain.SpecialCode = new Domain.SpecialCode();
            domain.SpecialCode.Code = "special";
            var dataContract = _personMapper.Map(domain);
            return dataContract;
        }

        public Domain.Person GetDomainAbstractPerson()
        {
            var dataContract = new DataContracts.Person { Name = "Scully" };
            dataContract.Address.Street = "58th Street";
            var concrete = new DataContracts.OtherConcreteClass();
            concrete.Description = "description";
            dataContract.AbstractClass = concrete;
            var domain = _personMapper.Map(dataContract);
            return domain;
        }
    }
}
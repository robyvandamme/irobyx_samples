using Person=AutoMapperAutofac.Domain.Person;

namespace AutoMapperAutofac.ServiceLayer
{
    public interface IPersonService
    {
        DataContracts.Person GetPerson();
        DataContracts.Person GetDataContractsAbstractPerson();
        Person GetDomainAbstractPerson();
    }
}
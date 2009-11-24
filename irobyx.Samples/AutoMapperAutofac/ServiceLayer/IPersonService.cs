
namespace irobyx.AutoMapperSample.ServiceLayer
{
    public interface IPersonService
    {
        DataContracts.Person GetPerson();
        DataContracts.Person GetDataContractsAbstractPerson();
        Domain.Person GetDomainAbstractPerson();
    }
}
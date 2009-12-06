
namespace irobyx.AutoMapperSample.ServiceLayer
{
    public interface IPersonService
    {
        DataContracts.Person GetDataContractsAbstractPerson();
        Domain.Person GetDomainAbstractPerson();
    }
}
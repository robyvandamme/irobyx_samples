using Autofac;
using Autofac.Builder;
using irobyx.AutoMapperSample.MapperConfiguration;
using irobyx.AutoMapperSample.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using irobyx.AutoMapperSample.ServiceLayer;

namespace irobyx.AutoMapperSample.Tests
{
    [TestClass]
    public class PersonServiceTest
    {
        private IContainer _container;

        [TestInitialize()]
        public void Configure()
        {
            var builder = new ContainerBuilder();
            // automapper registrations
            AutoMapperContainerConfiguration.ConfigureContainer(builder);
            // configure profiles
            // TODO: configuration from container
            AutoMapperConfiguration.Configure();
            // register mapper
            builder.RegisterGeneric(typeof(DomainMapper<,>)).As(typeof(IDomainMapper<,>)).
                ContainerScoped().OnActivating(ActivatingHandler.InjectProperties);
         
            builder.Register(c => new PersonService(c.Resolve<IDomainMapper<Domain.Person, DataContracts.Person>>())).As
                <IPersonService>().FactoryScoped();
            _container = builder.Build();
        }

        [TestMethod]
        public void when_configured_then_personservice_will_return_persons()
        {
            var service = _container.Resolve<IPersonService>();
            var person1 = service.GetDataContractsAbstractPerson();
            var person2 =service.GetDomainAbstractPerson();
            Assert.IsNotNull(person1);
            Assert.IsInstanceOfType(person1, typeof(DataContracts.Person));
            Assert.IsNotNull(person2);
            Assert.IsInstanceOfType(person2, typeof(Domain.Person));
        }
    }
}

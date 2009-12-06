using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Builder;
using Autofac;
using irobyx.AutoMapperSample.Mappers;
using AutoMapper;
using irobyx.AutoMapperSample.MapperConfiguration;

namespace irobyx.AutoMapperSample.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DomainMapperTest
    {
        private IContainer _container;

        [TestInitialize]
        public void Configure()
        {
            var builder = new ContainerBuilder();
            // automapper registrations
            AutoMapperContainerConfiguration.ConfigureContainer(builder);
            // configure profiles
            AutoMapperConfiguration.Configure();
            // register mapper
            builder.RegisterGeneric(typeof(DomainMapper<,>)).As(typeof(IDomainMapper<,>)).
                ContainerScoped().OnActivating(ActivatingHandler.InjectProperties);
            _container = builder.Build();
        }

        [TestMethod]
        public void when_configured_then_configuration_is_valid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void when_configured_then_mapping_engine_from_container_is_not_null()
        {
            var engine = _container.Resolve<IMappingEngine>();
            Assert.IsNotNull(engine);
        }
        
        [TestMethod]
        public void when_configured_then_domainmapper_from_container_is_not_null()
        {
            var mapper = _container.Resolve<IDomainMapper<Domain.Person, DataContracts.Person>>();
            Assert.IsNotNull(mapper);
        }

        [TestMethod]
        public void when_configured_then_properties_can_be_mapped_both_ways()
        {

            // map from domain to datacontract
            var result = new DataContracts.Person();
            var source = new Domain.Person { Address = { City = "Mine" }, DateOfBirth = DateTime.Now };
            var concreteClass = new Domain.ConcreteClass { Name = "Jim" };
            source.AbstractClass = concreteClass;

            result = Mapper.Map(source, result);
            
            Assert.AreEqual(source.Address.City, result.Address.City);
            result.Address.City = "Some City";
            Assert.AreNotEqual(result.Address.City, source.Address.City);
            
            source = Mapper.Map(result, source);
            
            Assert.AreEqual(source.Address.City, result.Address.City);
            var concreteResult = result.AbstractClass as DataContracts.ConcreteClass;
            Assert.IsNotNull(concreteResult);
            Assert.AreEqual("Jim", concreteResult.Name);

            // see if we can map back
            var otherConcreteClass = new DataContracts.OtherConcreteClass();
            otherConcreteClass.Description = "Just a description";
            result.AbstractClass = otherConcreteClass;
            Mapper.Map(result, source);

            var otherConcreteResult = source.AbstractClass as Domain.OtherConcreteClass;
            Assert.IsNotNull(otherConcreteResult);
            Assert.AreEqual("Just a description", otherConcreteResult.Description);
        }

    }
}
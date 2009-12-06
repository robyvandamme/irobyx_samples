using System;
using AutoMapper;
using irobyx.AutoMapperSample.MapperConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace irobyx.AutoMapperSample.Tests
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestInitialize]
        public void Configure()
        {
            AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public void when_configured_then_configuration_is_valid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void when_configured_then_properties_can_be_mapped_both_ways()
        {
            // map from domain to datacontract
            var result = new DataContracts.Person();
            var source = new Domain.Person {Address = {City = "Mine"}, DateOfBirth = DateTime.Now};
            var concreteClass = new Domain.ConcreteClass {Name = "Jim"};
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
            Mapper.Map(result,source);

            var otherConcreteResult = source.AbstractClass as Domain.OtherConcreteClass;
            Assert.IsNotNull(otherConcreteResult);
            Assert.AreEqual("Just a description", otherConcreteResult.Description); 
        }
    }
}

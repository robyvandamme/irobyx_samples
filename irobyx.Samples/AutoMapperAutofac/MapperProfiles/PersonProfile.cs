using AutoMapperAutofac.DataContracts;
using AutoMapperTest.Extensions;
using Address=AutoMapperAutofac.Domain.Address;
using ConcreteClass=AutoMapperAutofac.Domain.ConcreteClass;
using OtherConcreteClass=AutoMapperAutofac.Domain.OtherConcreteClass;
using Person=AutoMapperAutofac.Domain.Person;

namespace AutoMapperTest.MapperProfiles
{
    public class PersonProfile: Profile
    {
        protected override string ProfileName
        {
            get
            {
                return "PersonProfile";
            }
        }

        protected override void Configure()
        {
            
            CreateMap<Person, AutoMapperAutofac.DataContracts.Person>().BothWays();
            
            

            CreateMap<Address, AutoMapperAutofac.DataContracts.Address>().BothWays();


            CreateMap<Person, AutoMapperAutofac.DataContracts.Person>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.SpecialCode.Code));
            CreateMap<AutoMapperAutofac.DataContracts.Person, Person>()
                .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.Code));

            CreateMap<ConcreteClass, AutoMapperAutofac.DataContracts.ConcreteClass>().BothWays();
            CreateMap<OtherConcreteClass, AutoMapperAutofac.DataContracts.OtherConcreteClass>().BothWays();
            CreateMap<AutoMapperAutofac.Domain.AbstractClass, AbstractClass>()
                .MapAbstractDomain()
                .Include<ConcreteClass, AutoMapperAutofac.DataContracts.ConcreteClass>()
                .Include<OtherConcreteClass, AutoMapperAutofac.DataContracts.OtherConcreteClass>();

            CreateMap<AbstractClass, AutoMapperAutofac.Domain.AbstractClass>()
                .MapAbstractDataContract()
                .Include<AutoMapperAutofac.DataContracts.ConcreteClass, ConcreteClass>()
                .Include<AutoMapperAutofac.DataContracts.OtherConcreteClass, OtherConcreteClass>();

        }
    }
}
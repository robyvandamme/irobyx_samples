using AutoMapper;
using irobyx.AutoMapperSample.Extensions;

namespace irobyx.AutoMapperSample.MapperProfiles
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
            
            CreateMap<Domain.Address, DataContracts.Address>().BothWays();

            CreateMap<Domain.Person, DataContracts.Person>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.SpecialCode.Code));
            CreateMap<DataContracts.Person, Domain.Person>()
                .ForMember(dest => dest.SpecialCode, opt => opt.MapFrom(src => src.Code));

            CreateMap<Domain.ConcreteClass, DataContracts.ConcreteClass>().BothWays();
            CreateMap<Domain.OtherConcreteClass, DataContracts.OtherConcreteClass>().BothWays();

            CreateMap<Domain.AbstractClass, DataContracts.AbstractClass>()
                .MapAbstractDomain()
                .Include<Domain.ConcreteClass, DataContracts.ConcreteClass>()
                .Include<Domain.OtherConcreteClass, DataContracts.OtherConcreteClass>();

            CreateMap<DataContracts.AbstractClass, Domain.AbstractClass>()
                .MapAbstractDataContract()
                .Include<DataContracts.ConcreteClass, Domain.ConcreteClass>()
                .Include<DataContracts.OtherConcreteClass, Domain.OtherConcreteClass>();
        }
    }
}
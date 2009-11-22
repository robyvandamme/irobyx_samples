using Autofac;
using AutoMapper;
using AutoMapperTest.MapperProfiles;

namespace AutoMapperTest.MapperConfiguration
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<PersonProfile>());
        }
    }
}
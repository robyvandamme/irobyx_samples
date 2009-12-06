using AutoMapper;
using irobyx.AutoMapperSample.MapperProfiles;

namespace irobyx.AutoMapperSample.MapperConfiguration
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<PersonProfile>());
        }
    }
}
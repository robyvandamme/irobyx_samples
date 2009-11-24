using AutoMapper;
using irobyx.AutoMapperSample.MapperProfiles;

namespace irobyx.AutoMapperSample.MapperConfiguration
{
    public class AutoMapperConfiguration: IAutoMapperConfiguration
    {
        private IConfiguration _configuration;

        public AutoMapperConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddProfilesToConfiguration()
        {
            _configuration.AddProfile<PersonProfile>();
        }
    }
}
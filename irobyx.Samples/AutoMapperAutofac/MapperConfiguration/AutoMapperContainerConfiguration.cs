using Autofac;
using Autofac.Builder;
using AutoMapper;
using AutoMapperTest.Extensions;
using AutoMapperTest.MapperProfiles;

namespace AutoMapperTest.MapperConfiguration
{
    public class AutoMapperContainerConfiguration
    {
        public static void Configure(ContainerBuilder builder)
        {
            ConfigureContainer(builder);
            //ConfigureMapper();
        }

        public static void ConfigureMapper()
        { 
            Mapper.Initialize(x => x.AddProfile<PersonProfile>());
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            // Configure the container

            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
            builder.Register<TypeMapFactory>().As<ITypeMapFactory>();
            builder.Register(c => AutoMapper.Mappers.MapperRegistry.AllMappers());
            builder.Register<Configuration>()
                .As<Configuration>()
                .As<IConfigurationProvider>()
                .As<IConfiguration>(); 
        }

        public static  void AddProfilesToConfiguration(IConfiguration configuration)
        {
            configuration.AddProfile<PersonProfile>();
        }
    }

}
using Autofac.Builder;
using AutoMapper;

namespace irobyx.AutoMapperSample.Tests
{
    public class AutoMapperContainerConfiguration
    {
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
            builder.Register<TypeMapFactory>().As<ITypeMapFactory>();
            builder.Register(c => AutoMapper.Mappers.MapperRegistry.AllMappers());
            builder.Register<Configuration>()
                .As<Configuration>()
                .As<IConfigurationProvider>()
                .As<IConfiguration>(); 
        }
    }
}
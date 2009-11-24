using System;
using AutoMapper;

namespace irobyx.AutoMapperSample.Extensions
{
    public static class IMappingExpressionExtensions
    {
        /// <summary>
        /// Creates a map from destination to source as well
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="mappingExpression"></param>
        /// <returns></returns>
        public static IMappingExpression<TDestination, TSource> BothWays<TSource, TDestination>
            (this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            return Mapper.CreateMap<TDestination, TSource>();
        }

        public static IMappingExpression<TSource, TDestination> MapAbstractDomain<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : irobyx.AutoMapperSample.Domain.AbstractClass
            where TDestination : DataContracts.AbstractClass
        {
            return mappingExpression.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        public static IMappingExpression<TSource, TDestination> MapConcreteDomain<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : Domain.ConcreteClass
            where TDestination : DataContracts.ConcreteClass
        {
            return mappingExpression.ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number)).MapAbstractDomain();
        }

        public static IMappingExpression<TSource, TDestination> MapOtherConcreteDomain<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : Domain.OtherConcreteClass
            where TDestination : DataContracts.OtherConcreteClass
        {
            return mappingExpression.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).MapAbstractDomain();
        }

        public static IMappingExpression<TSource, TDestination> MapAbstractDataContract<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : DataContracts.AbstractClass
            where TDestination : Domain.AbstractClass
        {
            return mappingExpression.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        public static IMappingExpression<TSource, TDestination> MapConcreteDataContract<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : DataContracts.ConcreteClass
            where TDestination : Domain.ConcreteClass
        {
            return mappingExpression.ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number)).MapAbstractDataContract();
        }

        public static IMappingExpression<TSource, TDestination> MapOtherConcreteDataContract<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TSource : DataContracts.OtherConcreteClass
            where TDestination : Domain.OtherConcreteClass
        {
            return mappingExpression.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).MapAbstractDataContract();
        }
    }
}
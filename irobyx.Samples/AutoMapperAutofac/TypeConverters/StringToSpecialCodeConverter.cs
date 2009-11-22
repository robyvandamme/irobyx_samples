using System;
using AutoMapperAutofac.Domain;

namespace AutoMapperTest.TypeConverters
{
    public class StringToSpecialCodeConverter: AutoMapper.ITypeConverter<string, SpecialCode>
    {
        public SpecialCode Convert(string source)
        {
            return new SpecialCode{Code = source};
        }
    }
}
using AutoMapperAutofac.Domain;

namespace AutoMapperTest.TypeConverters
{
    public class SpecialCodeToStringConverter: AutoMapper.ITypeConverter<SpecialCode, string>
    {
        public string Convert(SpecialCode source)
        {
            return source.Code;
        }
    }
}
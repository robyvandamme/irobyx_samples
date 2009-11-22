namespace AutoMapperAutofac.ObjectMappers
{
    public interface IDomainMapper<TDomain, TDataContract>
        where TDataContract : class ,new()
        where TDomain : class, new()
    {
        TDataContract Map(TDomain domain);
        TDomain Map(TDataContract dataContract);
    }
}
using System;
using AutoMapper;

namespace irobyx.AutoMapperSample.Mappers
{
    public class DomainMapper<TDomain, TDataContract> :
        IDomainMapper<TDomain, TDataContract>
        where TDomain : class, new()
        where TDataContract : class, new()
    {
        public IMappingEngine Engine { get; set; }

        //private readonly IMappingEngine _engine;

        //public DomainMapper(IMappingEngine engine)
        //{
        //    _engine = engine;
        //}

        public TDataContract Map(TDomain domain)
        {
            if (domain == null)
                throw new ArgumentNullException("domain");
            return Engine.Map<TDomain, TDataContract>(domain);
        }

        public TDomain Map(TDataContract dataContract)
        {
            if (dataContract == null)
                throw new ArgumentNullException("dataContract");
            return Engine.Map<TDataContract, TDomain>(dataContract);
        }
    }
}
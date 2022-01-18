using AutoMapper;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Infrastructure.Data.Models;
using CurrencyExchange.Infrastructure.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ExchangeDataDto, ExchangeDataModel>().ReverseMap();
        CreateMap<ExchangeDataDto, IExchangeData>().ReverseMap();
        CreateMap<CurrencyDto, CurrencyModel>().ReverseMap();
        CreateMap<CurrencyDto, ICurrency>().ReverseMap();
    }
}
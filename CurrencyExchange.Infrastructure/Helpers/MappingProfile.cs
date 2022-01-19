using AutoMapper;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Infrastructure.Data.Models;
using CurrencyExchange.Infrastructure.Models;

public class MappingProfile : Profile
{
    //public MappingProfile()
    //{
    //    var config = new MapperConfiguration(cfg => {
    //        cfg.CreateMap<CurrencyDto, CurrencyModel>().ReverseMap();
    //       // cfg.CreateMap<CatalogueDefinitionFile, CatalogueDefinitionFileViewModel>().ReverseMap();
    //    });
    //    IMapper mapper = config.CreateMapper();
    //    CreateMap<ExchangeDataDto, ExchangeDataModel>().ReverseMap();
    //    CreateMap<ExchangeDataDto, IExchangeData>().ReverseMap();
    //    mapper.Map<CurrencyDto, CurrencyModel>(new CurrencyDto());
    //    CreateMap<CurrencyDto, ICurrency>().ReverseMap();
    //}

    public override string ProfileName
    {
        get
        {
            return "MappingProfile";
        }
    }

    public MappingProfile()
    {
        ConfigureMappings();
    }

    private void ConfigureMappings()
    {
        CreateMap<CurrencyDto, CurrencyModel>().ReverseMap();
        CreateMap<ExchangeDataDto, ExchangeDataModel>().ReverseMap();
        CreateMap<CurrencyDto, ICurrency>().ReverseMap();
        CreateMap<ExchangeDataDto, IExchangeData>().ReverseMap();
    }
}
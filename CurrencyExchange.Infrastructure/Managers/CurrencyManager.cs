using CurrencyExchange.Core.Enums;
using CurrencyExchange.Core.Managers;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Core.Repository;
using CurrencyExchange.Infrastructure.Models;
using CurrencyExchange.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyRepository currencyRepository;

        public CurrencyManager(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }
        private CurrencyDatas GetCurrencyFromNet()
        {
            try
            {
                string json = (new WebClient()).DownloadString("https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies/ka/json");
                return JsonConvert.DeserializeObject<CurrencyDatas>(json);
            }
            catch (Exception ex) {
                return null;
            }
        }
        public async Task<ICurrency> GetCurrencyRate(CurrencyType type)
        {
            switch (type)
            {
                case CurrencyType.USD:
                    return await currencyRepository.GetCurrencyByCode("USD");
                case CurrencyType.RUB:
                    return await currencyRepository.GetCurrencyByCode("RUB");
                case CurrencyType.GBP:
                    return await currencyRepository.GetCurrencyByCode("GBP");
                default:
                    return null;
            } 
        }
        public async Task<bool> GetCurrencyUpdate()
        {
            CurrencyDatas Items = GetCurrencyFromNet();
            var DbItems = await currencyRepository.GetAllCurrencyDatasAsync();
            if (DbItems.LastOrDefault().validFromDate != Items.date && Items != null)
            {
                await currencyRepository.UpdateCurrencyDatas(Items.currencies);
                return true;
            }
            return false;
        }
    }
}

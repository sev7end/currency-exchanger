using CurrencyExchange.Core.Enums;
using CurrencyExchange.Core.Managers;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Core.Repository;
using CurrencyExchange.Infrastructure.Models;
using CurrencyExchange.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                return JsonConvert.DeserializeObject<List<CurrencyDatas>>(json).First();
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
                    return await currencyRepository.GetCurrencyByCode("USD"); ;
                case CurrencyType.RUB:
                    return await currencyRepository.GetCurrencyByCode("RUB");
                case CurrencyType.GBP:
                    return await currencyRepository.GetCurrencyByCode("GBP");
                default:
                    return null;
            } 
        }
        public async Task GetCurrencyUpdate()
        {
            CurrencyDatas Items = GetCurrencyFromNet();
            var data = Items.currencies.Where(o => o.code == "USD" || o.code == "RUB" || o.code == "GBP").ToList();
            if (data != null)
                await currencyRepository.UpdateCurrencyDatas(ForAll<CurrencyModel,ICurrency>(data).ToList());
        }
        private IEnumerable<I> ForAll<T, I>(IList<T> lst) where T : I
        {
            foreach (I item in lst) yield return item;
        }
    }
}

using CurrencyExchange.Core.Enums;
using CurrencyExchange.Core.Managers;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Core.Repository;
using CurrencyExchange.Infrastructure.Models;
using CurrencyExchange.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Managers
{
    public class ExchangeManager : IExchangeManager
    {
        private readonly ICurrencyManager currencyManager;
        private readonly IExchangeRepository exchangeRepository;

        public ExchangeManager(ICurrencyManager currencyManager, IExchangeRepository exchangeRepository)
        {
            this.currencyManager = currencyManager;
            this.exchangeRepository = exchangeRepository;
        }
        public async Task<IExchangeData> RequestCurrencyExchange(string clientName, string personalNumber, int fromCurrency, int toCurrency, decimal amount)
        {
            await currencyManager.GetCurrencyUpdate();
            IExchangeData ConversionData = new ExchangeDataModel()
            {
                ClientName = clientName,
                PersonalNumber = personalNumber,
                Date = DateTime.Now,
                OriginAmount = amount,
                FromCurrency = (CurrencyType)fromCurrency,
                ToCurrency = (CurrencyType)toCurrency,
            };
            CurrencyModel currencyData = new CurrencyModel();
            if ((CurrencyType)fromCurrency == CurrencyType.GEL)
            {
                currencyData = await currencyManager.GetCurrencyRate((CurrencyType)toCurrency) as CurrencyModel;
                ConversionData.ConvertedAmount = (amount / currencyData.rate) * currencyData.quantity;
            }
            else
            {
                currencyData = await currencyManager.GetCurrencyRate((CurrencyType)fromCurrency) as CurrencyModel;
                ConversionData.ConvertedAmount = (amount * currencyData.rate) / currencyData.quantity;
            }
            ConversionData.Rate = currencyData.rate;
            ConversionData.Id = await exchangeRepository.AddExchangeDataAsync(ConversionData);
            return ConversionData;
        }
    }
}

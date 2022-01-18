using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Managers
{
    public interface IExchangeManager
    {
        Task<IExchangeData> RequestCurrencyExchange(string clientName, string personalNumber, int fromCurrency, int toCurrency, decimal amount);
    }
}

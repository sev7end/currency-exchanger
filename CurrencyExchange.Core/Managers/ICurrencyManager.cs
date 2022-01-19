using CurrencyExchange.Core.Enums;
using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Managers
{
    public interface ICurrencyManager
    {
        Task GetCurrencyUpdate();
        Task<ICurrency> GetCurrencyRate(CurrencyType type);
    }
}

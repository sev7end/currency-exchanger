using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Repository
{
    public interface ICurrencyRepository
    {
        Task AddCurrencyAsync(ICurrency model);
        Task DeleteCurrencyAsync(int id);
        Task<List<ICurrency>> GetAllCurrencyDatasAsync();
        Task UpdateCurrencyDatas(List<ICurrency> newData);
        Task<ICurrency> GetCurrencyByCode(string code);
    }
}

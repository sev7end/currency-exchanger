using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Repository
{
    public interface IExchangeRepository
    {
        Task<int> AddExchangeDataAsync(IExchangeData model);
        Task DeleteExchangeDataAsync(int id);
        Task<List<IExchangeData>> GetAllExchangeDatasAsync();
    }
}

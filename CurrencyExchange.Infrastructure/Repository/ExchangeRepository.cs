using AutoMapper;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Core.Repository;
using CurrencyExchange.Infrastructure.Data;
using CurrencyExchange.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Repository
{
    public class ExchangeRepository : IExchangeRepository { 
        private readonly ExchangeCurrencyContext context;
        private readonly IMapper mapper;

        public ExchangeRepository(ExchangeCurrencyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<IExchangeData>> GetAllExchangeDatasAsync()
        {
            var records = await context.ExchangeDatas.ToListAsync();
            return mapper.Map<List<IExchangeData>>(records);
        }

        public async Task AddExchangeDataAsync(IExchangeData model)
        {
            var item = mapper.Map<ExchangeDataDto>(model);
            context.ExchangeDatas.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteExchangeDataAsync(int id)
        {
            var record = await context.ExchangeDatas.FirstOrDefaultAsync(o => o.Id == id);
            if (record != null)
            {
                context.ExchangeDatas.Remove(record);
                await context.SaveChangesAsync();
            }
        }
    }
}

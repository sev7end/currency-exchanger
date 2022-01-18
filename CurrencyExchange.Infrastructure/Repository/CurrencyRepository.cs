using AutoMapper;
using CurrencyExchange.Core.Models;
using CurrencyExchange.Core.Repository;
using CurrencyExchange.Infrastructure.Data;
using CurrencyExchange.Infrastructure.Data.Models;
using CurrencyExchange.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ExchangeCurrencyContext context;
        private readonly IMapper mapper;

        public CurrencyRepository(ExchangeCurrencyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICurrency> AddCurrencyAsync(ICurrency model)
        {
            context.ExchangeRates.Add(mapper.Map<CurrencyDto>(model));
            await context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            var record = await context.ExchangeRates.FirstOrDefaultAsync(o => o.Id == id);
            if (record != null)
            {
                context.ExchangeRates.Remove(record);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ICurrency>> GetAllCurrencyDatasAsync()
        {
            var records = await context.ExchangeRates.ToListAsync();
            return mapper.Map<List<ICurrency>>(records);
        }

        public async Task<ICurrency> GetCurrencyByCode(string code)
        {
            var record = await context.ExchangeRates.FirstOrDefaultAsync(o=> o.code == code);
            return mapper.Map<ICurrency>(record);
        }

        public async Task UpdateCurrencyDatas(List<ICurrency> newData)
        {
            context.ExchangeRates = mapper.Map<DbSet<CurrencyDto>>(newData);
            await context.SaveChangesAsync();
        }
    }
}

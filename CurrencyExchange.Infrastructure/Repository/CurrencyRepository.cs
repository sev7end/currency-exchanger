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

        public async Task AddCurrencyAsync(ICurrency model)
        {
            var cModel = model as CurrencyModel;
            var item = mapper.Map<CurrencyDto>(cModel);
            context.ExchangeRates.Add(item);
            await context.SaveChangesAsync();
        }

        public Task DeleteCurrencyAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task DeleteCurrencyAsync(int id)
        //{
        //    var record = await context.ExchangeRates.FirstOrDefaultAsync(o => o.Id == id);
        //    if (record != null)
        //    {
        //        context.ExchangeRates.Remove(record);
        //        await context.SaveChangesAsync();
        //    }
        //}

        public async Task<List<ICurrency>> GetAllCurrencyDatasAsync()
        {
            var records = await context.ExchangeRates.ToListAsync();
            return mapper.Map<List<ICurrency>>(records);
        }

        public async Task<ICurrency> GetCurrencyByCode(string code)
        {
            var record = await context.ExchangeRates.FirstOrDefaultAsync(o=> o.code == code);
            var item = mapper.Map<ICurrency>(record);
            return item;
        }

        public async Task UpdateCurrencyDatas(List<ICurrency> newData)
        {
            if (context.ExchangeRates.Count() != 0)
            {
                foreach (var item in context.ExchangeRates)
                {
                    context.ExchangeRates.Remove(item);
                }
                await context.SaveChangesAsync();
            }
            if (newData.Count == 0) return;
            foreach(var item in newData)
            {
                await AddCurrencyAsync(item);
            }
        }
    }
}

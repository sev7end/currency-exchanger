using CurrencyExchange.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Data
{
    public class ExchangeCurrencyContext : DbContext
    {
        public ExchangeCurrencyContext(DbContextOptions<ExchangeCurrencyContext> options)
            : base(options)
        {
        }
        public DbSet<ExchangeDataDto> ExchangeDatas { get; set; }
        public DbSet<CurrencyDto> ExchangeRates { get; set; }
    }
}

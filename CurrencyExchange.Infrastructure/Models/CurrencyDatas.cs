using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Models
{
    public class CurrencyDatas
    {
        public DateTime date { get; set; }
        public List<ICurrency> currencies { get; set; }
    }
}

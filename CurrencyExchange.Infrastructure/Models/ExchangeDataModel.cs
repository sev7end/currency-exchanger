using CurrencyExchange.Core.Enums;
using CurrencyExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Infrastructure.Models
{
    public class ExchangeDataModel : IExchangeData
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string PersonalNumber { get; set; }
        public CurrencyType FromCurrency { get; set; }
        public CurrencyType ToCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal OriginAmount { get; set; }
        public decimal ConvertedAmount { get; set; }
        public DateTime Date { get; set; }
    }
}

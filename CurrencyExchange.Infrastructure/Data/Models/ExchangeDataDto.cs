using CurrencyExchange.Core.Enums;
using System;

namespace CurrencyExchange.Infrastructure.Data.Models
{
    public class ExchangeDataDto
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

using CurrencyExchange.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Models
{
    public interface IExchangeData
    {
        int Id { get; set; }
        string ClientName { get; set; }
        string PersonalNumber { get; set; }
        CurrencyType FromCurrency { get; set; }
        CurrencyType ToCurrency { get; set; }
        decimal Rate { get; set; }
        decimal OriginAmount { get; set; }
        decimal ConvertedAmount { get; set; }
        DateTime Date { get; set; }
    }
}

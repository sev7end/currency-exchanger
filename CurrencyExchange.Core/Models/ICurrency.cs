using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Core.Models
{
    public interface ICurrency
    {
        string code { get; set; }
        DateTime date { get; set; }
        decimal diff { get; set; }
        string diffFormated { get; set; }
        string name { get; set; }
        int quantity { get; set; }
        decimal rate { get; set; }
        string rateFormated { get; set; }
        DateTime validFromDate { get; set; }
    }
}

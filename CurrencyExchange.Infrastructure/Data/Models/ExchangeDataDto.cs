using CurrencyExchange.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Infrastructure.Data.Models
{
    public class ExchangeDataDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        [StringLength(11)]
        public string PersonalNumber { get; set; }

        [Required]
        [Range(0,3)]
        public CurrencyType FromCurrency { get; set; }

        [Required]
        [Range(0, 3)]
        public CurrencyType ToCurrency { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public decimal OriginAmount { get; set; }

        [Required]
        public decimal ConvertedAmount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Currency.Data
{
    //If the number of tables had more than one,
    //Separate entities and datacontext and add new class library
    public class Tbl_exchange_rates
    {
        public int ID { get; set; }

        [DisplayName("Currency Code")]
        [StringLength(maximumLength: 3, ErrorMessage = "up to 3 characters")]
        public string CurrencyCode { get; set; }

        public string Unit { get; set; }
        public string CurrencyName { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }

        public DateTime? LastUpdate { get; set; } = DateTime.Now;
    }
}

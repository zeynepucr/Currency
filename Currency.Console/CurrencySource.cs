using Currency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Currency.Console
{
    static class CurrencySource
    {
        private const string SourceUrl = "http://www.tcmb.gov.tr/kurlar/today.xml";

        public static IEnumerable<Tbl_exchange_rates> GetRates(Byte recordCount)
        {
            //Getting exchange rate information from link
            XElement exchange = XElement.Load(SourceUrl);

            var query = from ex in exchange.Elements()
                        select new Tbl_exchange_rates
                        {
                            CurrencyCode = ex.Attribute("CurrencyCode").Value.ToString(),
                            Unit = ex.Element("Unit").Value.ToString(),
                            CurrencyName = ex.Element("CurrencyName").Value.ToString(),
                            ForexBuying = ex.Element("ForexBuying").Value.ToString(),
                            ForexSelling = ex.Element("ForexSelling").Value.ToString(),
                            BanknoteBuying = ex.Element("BanknoteBuying").Value.ToString(),
                            BanknoteSelling = ex.Element("BanknoteSelling").Value.ToString()
                        };
            //Fetching currency data by requested record count.
            return query.Take(recordCount);
        }
    }
}

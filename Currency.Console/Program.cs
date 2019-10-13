using Currency.Data;
using Currency.Data.Abstract;
using System;
using System.Linq;
using System.Timers;

namespace Currency.Console
{
    class Program
    {
        private static IRepository<Tbl_exchange_rates> repo = null;

        static void Main(string[] args)
        {
            repo = new GenericRepository<Tbl_exchange_rates>();
            SetTimer();
        }

        private static void SetTimer()
        {
            //Data was displayed before the timer started
            GetCurrency(null, null);

            //Timer runs the program at 5-minute intervals
            using (var timer = new Timer(1000 * 60 * 5))
            {
                timer.Elapsed += new ElapsedEventHandler(GetCurrency);
                timer.Enabled = true;
                timer.Start();
                System.Console.ReadLine();
            }
        }
        private static void GetCurrency(object source, ElapsedEventArgs e)
        {
            try
            {
                //List of data in the database
                var dbRates = repo.GetAll();

                //Current data from the GetRates method
                var currentRates = CurrencySource.GetRates(12);

                foreach (var item in currentRates)
                {
                    var rate = dbRates.FirstOrDefault(r => r.CurrencyCode == item.CurrencyCode);

                    //Updated if the exchange rate is registered in the database,otherwise added
                    if (rate != null)
                    {
                        rate.ForexBuying = item.ForexBuying;
                        rate.ForexSelling = item.ForexSelling;
                        rate.BanknoteBuying = item.BanknoteBuying;
                        rate.BanknoteSelling = item.BanknoteSelling;
                        rate.LastUpdate = DateTime.Now;
                    }

                    else
                    {
                        repo.Add(item);
                    }

                    repo.Save();
                }
                System.Console.WriteLine("{0} Currencies updated.", DateTime.Now);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("{0} Error : {1}", DateTime.Now, ex.Message);
                throw;
            }
        }
    }
}

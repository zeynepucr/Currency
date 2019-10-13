using System.Data.Entity;

namespace Currency.Data
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DataContext") { }

        public DbSet<Tbl_exchange_rates> ExchangeRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

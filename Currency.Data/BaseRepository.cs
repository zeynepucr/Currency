
namespace Currency.Data
{

    public class BaseRepository
    {
        protected static DataContext db;
        private static object locker = new object();

        protected BaseRepository()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (db == null)
            {
                //For Multithreading Applications
                lock (locker)
                {
                    db = new DataContext();
                }
            }
        }
    }
}

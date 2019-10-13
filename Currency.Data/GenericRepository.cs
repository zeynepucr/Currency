using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Currency.Data.Abstract;

namespace Currency.Data
{
    public class GenericRepository<T> : BaseRepository, IRepository<T> where T : class
    {
        private DbSet<T> _objectSet;

        public GenericRepository()
        {
            _objectSet = db.Set<T>();
        }

        //Repository pattern<t> instead of writing methods that insert, update, delete in all classes

        #region Operations
        public List<T> GetAll()
        {
            return _objectSet.ToList();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return Save();
        }

        public int Delete(T entity)
        {
            _objectSet.Remove(entity);
            return Save();
        }

        public T GetById(object id)
        {
            return _objectSet.Find(id);
        }

        public void Add(T entity)
        {
             _objectSet.Add(entity);
        }
        
        #endregion
    }
}

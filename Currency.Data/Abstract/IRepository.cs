using System.Collections.Generic;

namespace Currency.Data.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        int Save();
        int Update(T entity);
        int Delete(T entity);
        void Add(T entity);
        T GetById(object id);
        
    }
}

using System.Collections.Generic;

namespace ContactManagement.Data
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(object i);

        void Save();
    }
}

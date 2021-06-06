using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.Data
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> GetById(object id);

        Task Insert(T entity);

        void Update(T entity);

        Task Delete(object i);

        Task Save();
    }
}

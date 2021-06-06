using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private DbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            table = context.Set<T>();
        }
        public async virtual Task<ICollection<T>> GetAll()
        {
            return await table.ToListAsync();
        }
        public async virtual Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        public async virtual Task Insert(T obj)
        {
            await table.AddAsync(obj);
        }
        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async virtual Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async virtual Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

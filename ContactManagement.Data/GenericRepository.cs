using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        public virtual ICollection<T> GetAll()
        {
            return table.ToList();
        }
        public virtual T GetById(object id)
        {
            return table.Find(id);
        }
        public virtual void Insert(T obj)
        {
            table.Add(obj);
        }
        public virtual void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}

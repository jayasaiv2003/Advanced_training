
using Inventory_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ProductInventoryContext _dbcontext;
        private DbSet<T> _dbset;
        public GenericRepository(ProductInventoryContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbset = _dbcontext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
            _dbcontext.SaveChanges();

        }

        public void Delete(int id)
        {
            var a = _dbcontext.Find<T>(id);
            if (a != null)
            {
                _dbset.Remove(a);
                _dbcontext.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            return _dbcontext.Find<T>(id);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _dbcontext.SaveChanges();

        }
    }
}

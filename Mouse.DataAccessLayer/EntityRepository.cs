using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mouse.Interfaces;

namespace Mouse.DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(DBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existingEntity = _dbSet.Find(entity.ID);

            if (existingEntity != null)
            {
                _dbSet.Remove(existingEntity);
                _context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            T existingEntity = _dbSet.Find(entity.ID);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues
                    .SetValues(entity);

                _context.SaveChanges();
            }
        }
    }
}

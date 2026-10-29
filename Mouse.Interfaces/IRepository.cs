using System.Collections.Generic;

namespace Mouse.Interfaces
{
    public interface IRepository<T> where T : IDomainObject
    {
        void Add(T entity);

        void Delete(T entity);

        List<T> GetAll();

        T GetById(int id);

        void Update(T entity);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppLightpoint.DAL.Entities;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.DAL.Repository
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _uow;

        public CommonRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public virtual async Task CreateAsync(T item)
        {
            if (item == null) throw new Exception("Значения модели не описаны");
            await _uow.Context.Set<T>().AddAsync(item);
             _uow.Commit();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbEntry = await _uow.Context.Set<T>().FindAsync(id);
            if (dbEntry == null) throw new Exception("Значения модели не описаны");
            _uow.Context.Remove(dbEntry);
            _uow.Commit();
        }

        public virtual async Task<T> GetSingleAsync(int id)
        {
            return await _uow.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _uow.Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual void Update(T item)
        {
            var exist = _uow.Context.Set<T>().Find(item.Id);
            _uow.Context.Entry(exist).CurrentValues.SetValues(item);
            _uow.Commit();
        }

        public async Task<IEnumerable<T>> FindList(Func<T, bool> predicate)
        {
            return  _uow.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }
    }
}

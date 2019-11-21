using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.DAL.Repository
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : class
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
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbEntry = await _uow.Context.Set<T>().FindAsync(id);
            if (dbEntry == null) throw new Exception("Значения модели не описаны");
            _uow.Context.Remove(dbEntry);
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
            _uow.Context.Entry(item).State = EntityState.Modified;
            _uow.Context.Set<T>().Attach(item);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLightpoint.DAL.Interface
{
    public interface ICommonRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(int id);
        Task CreateAsync(T item);
        void Update(T item);
        Task DeleteAsync(int id);

    }
}

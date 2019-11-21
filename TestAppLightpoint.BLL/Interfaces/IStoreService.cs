using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.BLL.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllStoreAsync();
        Task<Store> GetSingleStoreAsync(int id);
        void UpdateStore(StoreDTO item);
        Task DeleteStoreAsync(int id);
        Task CreateStoreAsync(StoreDTO item);
    }
}

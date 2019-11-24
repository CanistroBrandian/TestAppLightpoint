using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.BLL.Interfaces;
using TestAppLightpoint.DAL.Entities;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.BLL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _repositoryStore;

        public StoreService(IStoreRepository repo)
        {
            _repositoryStore = repo;
        }

        public async Task CreateStoreAsync(StoreDTO item)
        {
            if (item != null)
            {
                Store newStore = new Store
                {
                    Name = item.Name,
                    Address = item.Address,
                    OpeningTimes = item.OpeningTimes
                };
                await _repositoryStore.CreateAsync(newStore);
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task DeleteStoreAsync(int id)
        {
            await _repositoryStore.DeleteAsync(id);
        }

        public async Task<IEnumerable<StoreDTO>> GetAllStoreAsync()
        {
            var listStore = await _repositoryStore.GetAllAsync();
            IEnumerable<StoreDTO> listStoreDTO = listStore.ToList().ConvertAll(t => new StoreDTO
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                OpeningTimes = t.OpeningTimes
            });
            return listStoreDTO;
        }

        public async Task<StoreDTO> GetSingleStoreAsync(int id)
        {
            var store = await _repositoryStore.GetSingleAsync(id);
            StoreDTO storeDTO = new StoreDTO()
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address,
                OpeningTimes = store.OpeningTimes
            };
            return storeDTO;
        }

        public async Task UpdateStore(StoreDTO item)
        {
            var sourceStore = await _repositoryStore.GetSingleAsync(item.Id);

            if (sourceStore != null)
            {
                Store store = new Store()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    OpeningTimes = item.OpeningTimes
                };
                _repositoryStore.Update(store);
            }
            else throw new Exception("Такой записи нет");
        }
    }
}

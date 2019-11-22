using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.BLL.Interfaces;
using TestAppLightpoint.DAL.Entities;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.BLL.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _uow;
        private readonly IStoreRepository _repositoryStore;

        public StoreService(IUnitOfWork unitOfWork, IStoreRepository repo)
        {
            _uow = unitOfWork;
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
                _uow.Commit();
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task DeleteStoreAsync(int id)
        {
            await _repositoryStore.DeleteAsync(id);
            _uow.Commit();
        }

        public async Task<IEnumerable<Store>> GetAllStoreAsync()
        {
            return await _repositoryStore.GetAllAsync();
        }

        public async Task<Store> GetSingleStoreAsync(int id)
        {
           return await _repositoryStore.GetSingleAsync(id);
        }

        public void UpdateStore(StoreDTO item)
        {
            var sourceStore = _repositoryStore.GetSingleAsync(item.Id);

            if (sourceStore != null)
            {
                Store store = new Store()
                {
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

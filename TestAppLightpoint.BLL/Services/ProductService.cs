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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductRepository _repositoryProduct;
        private readonly IStoreRepository _repositoryStore;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repoProduct, IStoreRepository repoStore)
        {
            _uow = unitOfWork;
            _repositoryProduct = repoProduct;
            _repositoryStore = repoStore;
        }
        public async Task CreateProductAsync(ProductDTO item)
        {
            if (item != null)
            {
                Product newProduct = new Product
                {
                    Name = item.Name,
                    Description = item.Description,
                    StoreId = item.StoreId
                };
                await _repositoryProduct.CreateAsync(newProduct);
                _uow.Commit();
            }
            else throw new Exception("Данные не заполнены");
        }

        public async Task AddProductInStore(int idStore, ProductDTO sourceProduct)
        {
            Product product = new Product
            {
                Name = sourceProduct.Name,
                Description = sourceProduct.Description,
                Store = await _repositoryStore.GetSingleAsync(idStore)
            };

            await _repositoryProduct.CreateAsync(product);
            _uow.Commit();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsOfStore(int StoreId)
        {

            var listProducts = await _repositoryProduct.FindList(src => src.StoreId == StoreId);

            IEnumerable<ProductDTO> listProductDTOs = listProducts.ToList().ConvertAll(t => new ProductDTO
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                StoreId = t.StoreId,
                Store = t.Store
            });

            return listProductDTOs;
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repositoryProduct.DeleteAsync(id);
            _uow.Commit();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _repositoryProduct.GetAllAsync();
        }

        public Task<Product> GetSingleProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductDTO item)
        {
            var sourceProduct = _repositoryProduct.GetSingleAsync(item.Id);

            if (sourceProduct != null)
            {
                Product product = new Product()
                {
                    Name = item.Name,
                    Description = item.Description
                };
                _repositoryProduct.Update(product);
            }
            else throw new Exception("Такой записи нет");
        }
    }
}

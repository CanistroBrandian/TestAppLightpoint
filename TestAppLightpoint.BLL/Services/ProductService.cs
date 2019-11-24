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
        private readonly IProductRepository _repositoryProduct;
        private readonly IStoreRepository _repositoryStore;

        public ProductService(IProductRepository repoProduct, IStoreRepository repoStore)
        {
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
            });

            return listProductDTOs;
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repositoryProduct.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            var listProducts =  await _repositoryProduct.GetAllAsync();
            IEnumerable<ProductDTO> listProductDTOs = listProducts.ToList().ConvertAll(t => new ProductDTO
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                StoreId = t.StoreId,
            });
            return listProductDTOs;
        }

        public async Task<ProductDTO> GetSingleProductAsync(int id)
        {
            var product = await _repositoryProduct.GetSingleAsync(id);
            ProductDTO productDTO = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                StoreId = product.StoreId
            };
            return productDTO;
        }

        public async Task UpdateProduct(ProductDTO item)
        {
            var sourceProduct = await _repositoryProduct.GetSingleAsync(item.Id);


            if (sourceProduct != null)
            {
                sourceProduct.Name = item.Name;
                sourceProduct.Description = item.Description;              
                _repositoryProduct.Update(sourceProduct);
            }
            else throw new Exception("Такой записи нет");
        }
    }
}

using System;
using System.Collections.Generic;
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
        private readonly ICommonRepository<Product> _repositoryProduct;

        public ProductService(IUnitOfWork unitOfWork, ICommonRepository<Product> repo)
        {
            _uow = unitOfWork;
            _repositoryProduct = repo;
        }
        public async Task CreateProductAsync(ProductDTO item)
        {
            if (item != null)
            {
                Product newProduct = new Product
                {
                    Name = item.Name,
                    Description = item.Description
                };
                await _repositoryProduct.CreateAsync(newProduct);
                _uow.Commit();
            }
            else throw new Exception("Данные не заполнены");
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

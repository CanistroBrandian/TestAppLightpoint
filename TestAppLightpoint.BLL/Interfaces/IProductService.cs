﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductAsync();
        Task<ProductDTO> GetSingleProductAsync(int id);
        Task UpdateProduct(ProductDTO item);
        Task DeleteProductAsync(int id);
        Task CreateProductAsync(ProductDTO item);
        Task<IEnumerable<ProductDTO>> GetAllProductsOfStore(int storeId);
    }
}

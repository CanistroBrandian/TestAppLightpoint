using System.Collections.Generic;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetSingleProductAsync(int id);
        void UpdateProduct(ProductDTO item);
        Task DeleteProductAsync(int id);
        Task CreateProductAsync(ProductDTO item);
    }
}

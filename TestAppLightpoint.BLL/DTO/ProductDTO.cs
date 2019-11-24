using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StoreId { get; set; }
        public StoreDTO Store { get; set; }
    }
}

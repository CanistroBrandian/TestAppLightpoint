using System.Collections.Generic;
using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.BLL.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningTimes { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

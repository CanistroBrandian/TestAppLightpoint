using System.Collections.Generic;

namespace TestAppLightpoint.DAL.Entities
{
    public class Store :BaseEntity
    {
        public string Address { get; set; }
        public string OpeningTimes { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

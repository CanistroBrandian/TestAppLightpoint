using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppLightpoint.DAL.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OpeningTimes { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

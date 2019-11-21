using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppLightpoint.DAL.Entities
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Store> Stores { get; set; }
    }
}

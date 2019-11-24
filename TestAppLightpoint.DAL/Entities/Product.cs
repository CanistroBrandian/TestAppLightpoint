using System;
using System.Collections.Generic;
using System.Text;

namespace TestAppLightpoint.DAL.Entities
{
   public class Product : BaseEntity
    {
        public string Description { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
    }
}

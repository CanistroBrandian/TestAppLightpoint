using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;

namespace TestAppLightpoint.Web.Models
{
    public class ProductListViewModel
    {       
            public IEnumerable<ProductViewModel> ListProduct { get; set; }     
            public StoreDTO Store { get; set; }
        
    }
}

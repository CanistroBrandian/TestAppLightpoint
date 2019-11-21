using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppLightpoint.Web.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Название продукта")]
        public string Name { get; set; }
        [Display(Name = "Описание продукта")]
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppLightpoint.Web.Models
{
    public class StoreViewModel
    {
        [Display(Name = "Название магазина")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Время работы")]
        public string OpeningTimes { get; set; }
    }
}

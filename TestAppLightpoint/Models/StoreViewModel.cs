using System.ComponentModel.DataAnnotations;

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

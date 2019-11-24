using System.ComponentModel.DataAnnotations;

namespace TestAppLightpoint.Web.Models
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название магазина")]
        [Required(ErrorMessage = "Не указано название магазина")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Не указан адрес магазина")]
        public string Address { get; set; }
        [Display(Name = "Время работы")]
        [Required(ErrorMessage = "Не указано время работы")]
        public string OpeningTimes { get; set; }
    }
}

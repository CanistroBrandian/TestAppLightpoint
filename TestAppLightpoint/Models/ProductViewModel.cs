using System.ComponentModel.DataAnnotations;
using TestAppLightpoint.BLL.DTO;

namespace TestAppLightpoint.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название продукта")]
        [Required(ErrorMessage = "Не указано название продукта")]
        public string Name { get; set; }
        [Display(Name = "Описание продукта")]
        [Required(ErrorMessage = "Не указано описание продукта")]
        public string Description { get; set; }
        [Display(Name = "Магазин")]
        public int? StoreId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleaningAdditionInputModel
    {
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Не указано время выполнения")]
        [RegularExpression(@"^(((0{1}|1{1})[0-9]{1})|(2{1}[0-3]{1}))+\:([0-5]{1}[0-9]{1})", 
            ErrorMessage = "Время выполнения должно быть указано в формате 'чч:мм'. Максимальное значение 23:59.")]
        public string Duration { get; set; }
    }
}

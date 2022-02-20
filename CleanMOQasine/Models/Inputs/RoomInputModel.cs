using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class RoomInputModel
    {
        [Required(ErrorMessage = "Введите наименование комнаты.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Наименование не должно содержать цифры.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите цену уборки.")]
        [RegularExpression("[0-9]+", ErrorMessage = "Введите корректную цену.")]
        public decimal Price { get; set; }
    }
}

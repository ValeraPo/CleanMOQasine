using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderUpdateInputModel
    {
        [Required(ErrorMessage = "Поле Тип уборки нельзя оставлять пустым.")]
        public int CleaningTypeId { get; set; }

        [Required(ErrorMessage = "Поле Адрес нельзя оставлять пустым.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Дата не может быть пустой.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Список комнат не может быть пустым.")]
        public List<int> RoomIds { get; set; }
        public List<int> CleaningAdditionIds { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleanerInsertInputModel : ClientInsertInputModel
    {
        [Required(ErrorMessage = "Введите телефон.")]
        [Phone(ErrorMessage = "Телефон введен некорректно.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Выберите виды уборки.")]
        public List<int> CleaningAdditionIds { get; set; }

        [Required(ErrorMessage = "Введите дни и время работы.")]
        public List<WorkingTimeInputModel> WorkingHours { get; set; }
    }
}

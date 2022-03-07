using CleanMOQasine.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleanerInsertInputModel : ClientInsertInputModel
    {
        [Required(ErrorMessage = "Введите телефон.")]
        [Phone(ErrorMessage = "Телефон введен некорректно.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Выберите виды уборки.")]
        [IsNoRepeatIds(ErrorMessage = "Id навыков не должны повторяться")]
        public List<int> CleaningAdditionIds { get; set; }

        [Required(ErrorMessage = "Введите дни и время работы.")]
        [IsNoRepeatDaysOfWeek(ErrorMessage = "В один день может быть только одна рабочая смена.")]
        public List<WorkingTimeInsertInputModel> WorkingHours { get; set; }
    }
}

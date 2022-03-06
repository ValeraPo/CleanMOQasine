using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleanerInsertInputModel : ClientInsertInputModel
    {
        [Required(ErrorMessage = "Выберите виды уборки.")]
        public List<int> CleaningAdditionIds { get; set; }

        [Required(ErrorMessage = "Введите дни и время работы.")]
        public List<WorkingTimeInputModel> WorkingHours { get; set; }
    }
}

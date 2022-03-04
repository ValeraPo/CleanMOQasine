using CleanMOQasine.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class WorkingTimeInputModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [RegularExpression(@"^[1-7]$", ErrorMessage = "Нужно указать цифру от 1 до 7, соответствующую дню недели.")]
        [IsTimeSpan(ErrorMessage = "Время выполнения должно быть указано в формате 'чч:мм'. Максимальное значение 23:59.")]
        public int Day { get; set; }
    }
}

using CleanMOQasine.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class WorkingTimeInsertInputModel
    {
        [IsTimeSpan(ErrorMessage = "Время должно быть указано в формате 'чч:мм'. Максимальное значение 23:59.")]
        public string StartTime { get; set; }

        [IsTimeSpan(ErrorMessage = "Время должно быть указано в формате 'чч:мм'. Максимальное значение 23:59.")]
        public string EndTime { get; set; }

        [Range(1, 7, ErrorMessage ="Цифра должна соответствовать дню недели, то есть от 1 (понедельник) до 7 (воскресенье)")]
        public int Day { get; set; }
    }
}

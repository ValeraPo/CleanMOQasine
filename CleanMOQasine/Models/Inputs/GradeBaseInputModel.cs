using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class GradeBaseInputModel
    {
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }

        [RegularExpression(@"[1-5]{1}", ErrorMessage = "Оценка должна быть от 1 до 5")]
        public int Rating { get; set; }
    }
}

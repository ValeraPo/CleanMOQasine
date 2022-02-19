using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class UserUpdateInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }

        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Телефон введен некорректно.")]
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public List<int>? CleaningAdditionIds { get; set; }
        public List<int>? WorkingTimeIds { get; set; }
    }
}

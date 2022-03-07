using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class UserUpdateInputModel
    {
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Посторонние символы. Используйте только буквы латинского алфавита или Кириллицу")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Посторонние символы. Используйте только буквы латинского алфавита или Кириллицу")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Телефон введен некорректно.")]
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public List<int>? CleaningAdditionIds { get; set; }
        public List<int>? WorkingTimeIds { get; set; }
    }
}

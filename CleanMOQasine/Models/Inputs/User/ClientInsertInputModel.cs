using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class ClientInsertInputModel
    {
        [Required(ErrorMessage = "Поле Email нельзя оставлять пустым.")]
        [EmailAddress(ErrorMessage = "Email введен некорректно!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле логина нельзя оставлять пустым.")]
        public string Login { get; set; }

        [Phone(ErrorMessage = "Телефон введен некорректно.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите имя.")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Посторонние символы. Используйте только буквы латинского алфавита или Кириллицу")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию.")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Посторонние символы. Используйте только буквы латинского алфавита или Кириллицу")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле пароля нельзя оставлять пустым.")]
        [MinLength(8, ErrorMessage = "Пароль должен быть длиннее 8 символов.")]
        [MaxLength(30, ErrorMessage = "Максимальная длина пароля 30 символов.")]
        public string Password { get; set; }
    }
}

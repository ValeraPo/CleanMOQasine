using CleanMOQasine.API.Validation;
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class UserInsertInputModel
    {
        [Required(ErrorMessage ="Поле Email нельзя оставлять пустым.")]
        [EmailAddress(ErrorMessage = "Email введен некорректно!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле логина нельзя оставлять пустым.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите имя.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Выберите роль пользователя.")]
        [RegularExpression(@"^[1-3]$", ErrorMessage = "Выберите роль пользователя.")]
        public int Role { get; set; }

        [Required(ErrorMessage = "Поле пароля нельзя оставлять пустым.")]
        [MinLength(9, ErrorMessage = "Ваш пароль недостаточно надежный.")]
        [MaxLength(30, ErrorMessage = "Пароль не может быть длиннее 30 символов.")]
        public string Password { get; set; }
    }
}

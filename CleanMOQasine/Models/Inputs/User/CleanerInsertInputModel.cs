using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleanerInsertInputModel
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

        [Required(ErrorMessage = "Поле пароля нельзя оставлять пустым.")]
        [MinLength(9, ErrorMessage = "Ваш пароль недостаточно надежный.")]
        [MaxLength(30, ErrorMessage = "Пароль не может быть длиннее 30 символов.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Выберите дополнения к уборке.")]
        public List<int> CleaningAdditionIds { get; set; }

        [Required(ErrorMessage = "Введите дни и время работы.")]
        public List<WorkingTimeInputModel> WorkingHours { get; set; }
    }
}

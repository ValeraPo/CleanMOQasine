using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class UserInsertInputModel
    {
        [Required(ErrorMessage ="Поле Email нельзя оставлять пустым.")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" 
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessage = "Email введен некорректно.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле логина нельзя оставлять пустым.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите имя.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле пароля нельзя оставлять пустым.")]
        [MaxLength(9, ErrorMessage = "Ваш пароль недостаточно надежный.")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class RoleUpdateInputModel
    {
        [Range(1, 3, ErrorMessage = "Введите цифру 1 - Админ, 2 - Клинер, 3 - Клиент")]
        public int Role { get; set; }
    }
}

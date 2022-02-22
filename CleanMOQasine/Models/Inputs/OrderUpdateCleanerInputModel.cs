using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderUpdateCleanerInputModel
    {
        [Required(ErrorMessage = "Поле Клинер нельзя оставлять пустым.")]
        public int CleanerId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderInsertInputModel : OrderUpdateInputModel
    {
        [Required(ErrorMessage = "Поле Клиент нельзя оставлять пустым.")]
        public int ClientId { get; set; } 
    }
}


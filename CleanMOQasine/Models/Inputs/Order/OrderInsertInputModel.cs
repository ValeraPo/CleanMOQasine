using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderInsertInputModel : OrderUpdateInputModel
    {
        [Required(ErrorMessage = "���� ������ ������ ��������� ������.")]
        public int ClientId { get; set; } 
    }
}


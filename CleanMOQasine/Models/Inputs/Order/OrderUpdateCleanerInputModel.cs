using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderUpdateCleanerInputModel
    {
        [Required(ErrorMessage = "���� ������ ������ ��������� ������.")]
        public int CleanerId { get; set; }
    }
}
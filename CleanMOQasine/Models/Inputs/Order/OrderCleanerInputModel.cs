using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderCleanerInputModel 
    {
        [Required(ErrorMessage = "���� ������ ������ ��������� ������.")]
        public int CleanerId { get; set; }
    }
}
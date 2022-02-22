using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class OrderUpdateInputModel
    {
        [Required(ErrorMessage = "���� ��� ������ ������ ��������� ������.")]
        public int CleaningTypeId { get; set; }

        [Required(ErrorMessage = "���� ����� ������ ��������� ������.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "���� �� ����� ���� ������.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "������ ������ �� ����� ���� ������.")]
        public List<int> RoomIds { get; set; }
        public List<int> CleaningAdditionIds { get; set; }
    }
}
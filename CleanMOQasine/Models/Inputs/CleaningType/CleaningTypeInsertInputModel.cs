using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class CleaningTypeInsertInputModel
    {
        [Required(ErrorMessage = "Название должно быть введено.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена должна быть введена.")]
        public decimal Price { get; set; }
    }
}

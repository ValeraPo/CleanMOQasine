using System.ComponentModel.DataAnnotations;

namespace CleanMOQasine.API.Models
{
    public class UserInsertInputModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

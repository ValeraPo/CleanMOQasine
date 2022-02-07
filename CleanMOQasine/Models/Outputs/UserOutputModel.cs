namespace CleanMOQasine.API.Models
{
    public class UserOutputModel : UserUpdateInputModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Rank { get; set; }
        public List<int>? OrderIds { get; set; }
    }
}

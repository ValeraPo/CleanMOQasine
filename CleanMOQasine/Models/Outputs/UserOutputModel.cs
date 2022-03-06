namespace CleanMOQasine.API.Models
{
    public class UserOutputModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Rank { get; set; }
        public List<CleaningAdditionOutputModel>? CleaningAdditions { get; set; }
        public List<int>? OrderIds { get; set; }

    }
}

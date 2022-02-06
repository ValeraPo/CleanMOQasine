namespace CleanMOQasine.API.Models.Inputs
{
    public class UserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<int>? CleaningAdditionIds { get; set; }
        public List<int>? WorkingTimeIds { get; set; }
    }
}

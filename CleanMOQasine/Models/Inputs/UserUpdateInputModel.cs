namespace CleanMOQasine.API.Models
{
    public class UserUpdateInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public List<int>? CleaningAdditionIds { get; set; }
        public List<int>? WorkingTimeIds { get; set; }
    }
}

namespace CleanMOQasine.Business.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public double? Rank { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<CleaningAdditionModel> CleaningAdditions { get; set; }
        //public virtual ICollection<WorkingTimeModel> WorkingTime { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
}

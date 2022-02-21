using CleanMOQasine.Data.Enums;

namespace CleanMOQasine.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double? Rank { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CleaningAddition>? CleaningAdditions { get; set; }
        public virtual ICollection<WorkingTime>? WorkingHours { get; set; }
        public virtual ICollection<Order>? ClientOrders { get; set; }
        public virtual ICollection<Order>? CleanerOrders { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            User user = (User)obj;
            if (user.Id == Id
                && user.FirstName == FirstName
                && user.LastName == LastName
                && user.Role == Role
                && user.PhoneNumber == PhoneNumber
                && user.Email == Email
                && user.Login == Login
                && user.Password == Password
                && user.Rank == Rank
                && user.IsDeleted == IsDeleted)
                return true;

            return false;
        }
    }
}

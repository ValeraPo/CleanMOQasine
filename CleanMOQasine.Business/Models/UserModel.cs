using CleanMOQasine.Data.Enums;

namespace CleanMOQasine.Business.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public List<CleaningAdditionModel> CleaningAdditions { get; set; }
        public List<WorkingTimeModel> WorkingHours { get; set; }
        public List<OrderModel> Orders { get; set; }
        public double? Rank 
        {
            get
            {
                if (Role is Role.Cleaner)
                {
                    var grades = Orders.Where(o=>o.Grade is not null).Select(o => o.Grade);
                    if (grades.Count() != 0)
                        return ((double)grades.Select(g => g.Rating).Sum()) / grades.Count();
                    else
                        return null;
                }
                return null;
            }
            private set { }
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            UserModel userModel = (UserModel)obj;
            if (userModel.Id == Id
                && userModel.FirstName == FirstName
                && userModel.LastName == LastName
                && userModel.Role == Role
                && userModel.Email == Email
                && userModel.Login == Login
                && userModel.Password == Password
                && userModel.PhoneNumber == PhoneNumber
                && userModel.IsDeleted == IsDeleted)
                return true;

            return false;
        }
    }
}

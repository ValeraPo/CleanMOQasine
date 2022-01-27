using CleanMOQasine.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public List<CleaningAdition> CleaningAditions { get; set; }
        public List<WorkingTime> WorkingTime { get; set; }
        public List<Order> Orders { get; set; }
        public double Rank { get; set; }


    }
}

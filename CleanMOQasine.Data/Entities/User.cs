﻿using CleanMOQasine.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanMOQasine.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double? Rank { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<CleaningAddition>? CleaningAdditions { get; set; }
        public virtual ICollection<WorkingTime>? WorkingTime { get; set; }
        public virtual ICollection<Order>? CleanerOrders { get; set; }
        public virtual ICollection<Order>? ClientOrders { get; set; }
    }
}

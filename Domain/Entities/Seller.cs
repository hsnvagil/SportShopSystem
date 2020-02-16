using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Seller : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Shop : BaseEntity
    {
        public Shop()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string LocalGovernmentArea { get; set; }
        public string Address { get; set; }
        public ICollection<Booking> Bookings { get; }
    }
}
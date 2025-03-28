using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Contacts = new HashSet<CustomerContact>();
            Bookings = new HashSet<Booking>();
        }
        public long UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public virtual ICollection<CustomerContact> Contacts { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

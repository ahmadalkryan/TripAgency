using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Customer
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty ;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Navigation Property
        public User? User { get; set; }
    }
}

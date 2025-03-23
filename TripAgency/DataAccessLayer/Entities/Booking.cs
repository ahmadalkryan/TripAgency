using DataAccessLayer.Entities.Common;
using DataAccessLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Booking : BaseEntity
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }
        //public int CustomerId { get; set; }
        public string BookingType { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public BookingStatusEnum Status { get; set; }
        //public int Employeeid { get; set; }
        public int NumOfPassengers { get; set; }
        
        public virtual CarBooking? CarBooking { get; set; }
        public virtual TripBooking? TripBooking { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        //public Customer? Customer { get; set; } 
        //public Employee Employee { get; set; }

    }
}

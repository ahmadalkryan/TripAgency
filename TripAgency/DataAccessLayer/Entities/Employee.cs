using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Employee
    {
        public Employee()
        {
           // Posts = new HashSet<Post>();
        }
        public DateTime HireDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        //public ICollection<Post> Posts { get; set; }
    }
}
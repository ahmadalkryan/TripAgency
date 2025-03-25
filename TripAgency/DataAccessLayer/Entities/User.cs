using DataAccessLayer.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class User : /*BaseEntity*/IdentityUser<long>
    {
        public string Password { get; set; } = string.Empty;
       // public Employee? Employee { get; set; }
        //public Customer? Customer { get; set; }
    }
}
using DataAccessLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class CustomerContact : BaseEntity
    {
        public long CustomerId { get; set; }
        public int ContactTypeId { get; set; }
        public string Value { get; set; } = string.Empty;
        public Customer? Customer { get; set; }
        public ContactType? ContactType { get; set; }
    }
}

using DataAccessLayer.Entities.Common;
using DataAccessLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ContactType : BaseEntity
    {
        public ContactType()
        {
            Contacts = new HashSet<CustomerContact>();
        }
        public ContactTypeEnum Type { get; set; }
        public virtual ICollection<CustomerContact> Contacts { get; set; }
    }
}

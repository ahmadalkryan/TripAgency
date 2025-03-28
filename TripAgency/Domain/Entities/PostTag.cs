using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PostTag
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
        public Tag? Tag { get; set; }
        public Post? Post { get; set; }
    }
}

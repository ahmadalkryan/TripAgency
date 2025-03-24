using DataAccessLayer.Entities.Common;
using DataAccessLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            PostTags = new HashSet<PostTag>();
        }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Body {  get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int Views { get; set; }
        public PostStatusEnum Status { get; set; }
        public DateTime PublishDate { get; set; }
        public string summary { get; set; } = string.Empty;

        public int AutherId { get; set; }
        public Employee? Auther { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}

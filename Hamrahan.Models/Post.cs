using System;
using System.Collections.Generic;


namespace Hamrahan.Models
{
    public partial class Post
    {
        public Post()
        {

        }

        public int Id { get; set; }
        public string ImagesLink { get; set; }
        public string PersonId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Published { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}

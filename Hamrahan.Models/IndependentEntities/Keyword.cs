using Hamrahan.Models.course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamrahan.Models
{
    public class Keyword
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Post> Posts{ get; set; }
        public ICollection<Course> Courses { get; set; }


    }
}

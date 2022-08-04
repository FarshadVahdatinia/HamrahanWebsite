using Hamrahan.Models;
using Hamrahan.Models.course;
using System.Collections.Generic;



namespace Hamrahan.Models
{
    public partial class Class
    {
        public Class()
        {
            Courses = new HashSet<Course>();
        }

        public byte Code { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

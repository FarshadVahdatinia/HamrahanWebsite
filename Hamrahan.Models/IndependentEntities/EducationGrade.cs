using Hamrahan.Models;
using Hamrahan.Models.course;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models
{
    public partial class EducationGrade
    {
        public EducationGrade()
        {
            People = new HashSet<Person>();
        }

        public byte Code { get; set; }
        public string Grade { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Person> People { get; set; }
    } 
}

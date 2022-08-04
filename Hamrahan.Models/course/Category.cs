using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models.course
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
            InverseSubCategoryNavigation = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public int? SubCategory { get; set; }

        public virtual Category SubCategoryNavigation { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Category> InverseSubCategoryNavigation { get; set; }
    }
}

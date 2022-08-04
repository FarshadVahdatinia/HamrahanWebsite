using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models.course
{
    public partial class Course
    {
        public Course()
        {
            Comments = new HashSet<Comment>();
            CourseEpisodes = new HashSet<CourseEpisode>();
            CoursePrices = new HashSet<CoursePrice>();
            OrderDetails = new HashSet<OrderDetail>();
            StudentPayments = new HashSet<StudentPayment>();
            UserCourses = new HashSet<UserCourse>();
        }

        public long Id { get; set; }
        public string TeacherId { get; set; }
        public byte? ClassCode { get; set; }
        public string Title { get; set; }
        public string TimeInWeek { get; set; }
        public DateTime? StartingDay { get; set; }
        public string CourseDescription { get; set; }
        public string CourseImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string Keyword { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Class ClassCodeNavigation { get; set; }
        public virtual Person Teacher { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CourseEpisode> CourseEpisodes { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<CoursePrice> CoursePrices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<StudentPayment> StudentPayments { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}

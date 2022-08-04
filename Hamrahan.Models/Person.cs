

using Hamrahan.Models.course;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamrahan.Models
{
    public partial class Person:IdentityUser
    {

        public Person()
        {
            Courses = new HashSet<Course>();
            SalaryPayments = new HashSet<SalaryPayment>();
            UserCourses = new HashSet<UserCourse>();
            StudentPayments = new HashSet<StudentPayment>();
            PersonPosts = new HashSet<Post>();
        

        }

            public string FirstName { get; set; }
            public string Lastname { get; set; }
            public string NationalCode { get; set; }
            public DateTime Birthdate { get; set; }
            
            public string TelePhone { get; set; }
            public string Address { get; set; }
            public string FullName { get; set; }
            public int? Age { get; set; }
            public bool Gender { get; set; }

             public DateTime RegisterDate { get; set; } 
            public byte EducationGradecode { get; set; }

            [ForeignKey("EducationGradecode")]
            public virtual EducationGrade EducationGradeNavigation { get; set; }



            public virtual ICollection<Order> Orders { get; set; }
            public virtual ICollection<Course> Courses { get; set; }
            public virtual ICollection<SalaryPayment> SalaryPayments { get; set; }
            public virtual ICollection<UserCourse> UserCourses { get; set; }
            public virtual ICollection<StudentPayment> StudentPayments { get; set; }
            public virtual ICollection<Post> PersonPosts{ get; set; }
            public virtual ICollection<Comment> Comments { get; set; }



    }
}

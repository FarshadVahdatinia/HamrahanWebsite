using Hamrahan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HamrahanTemplate.Application.DTOs
{
    public class ApiUpdateDTO
    {

        public string id { get; set; }

        [EmailAddress]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }



 
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


    
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "نام خانوادگی")]
        public string Lastname { get; set; }
        [Display(Name = "سن")]
        public int? Age { get; set; }

   
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { get; set; }


    
        [StringLength(150, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        [Display(Name = "تلفن منزل")]
        public string TelePhone { get; set; }
        /// <summary>
        /// فقط مخصوص نمایش
        /// </summary>
        [Display(Name = "مقطع تحصیلی")]
        public string EducationGradeName { get; set; }

       // [Required(ErrorMessage = "جنسیت را وارد کنید")]
        [Display(Name = "جنسیت")]
        public bool? Gender { get; set; }
        public string GenderForShow { get; set; }

      //  [Required(ErrorMessage = "تاریخ تولد را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public DateTime? Birthdate { get; set; }
        public byte? EducationGradeCode { get; set; }
        public virtual EducationGrade EducationGrade { get; set; }

        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        public override string ToString()
        {
            return $" {FirstName} {Lastname}";
        }

    }
}

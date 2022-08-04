using Hamrahan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HamrahanTemplate.Application.DTOs
{
    public class PersonDTO
    {
       
        
        [Required]
        [EmailAddress]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "نام خانوادگی")]
        public string Lastname { get; set; }


      
        [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }


        [Required(ErrorMessage = "تاریخ تولد را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// فقط برای نمایش تاریخ
        /// </summary>
        public string PersianBirthdate { get; set; }


        [Display(Name = "سن")]
        public int? Age { get; set; }


        [Required]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
        [Phone]
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength =10)]
        [Display(Name = "تلفن منزل")]
        public string TelePhone { get; set; }


        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
        [Display(Name = "آدرس")]
        public string Address { get; set; }



        /// <summary>
        /// فقط مخصوص نمایش
        /// </summary>
        [Display(Name = "مقطع تحصیلی")]
        public string EducationGradeName { get; set; }



        [Required(ErrorMessage = "مقطع تحصیلی را وارد کنید")]
        [Display(Name = "مقطع تحصیلی")]
        [ValidateNever]
        public SelectList EducationGrades { get; set; } 
        public byte EducationGradeCode { get; set; }
        public virtual EducationGrade EducationGrade{ get; set; }


        [Required(ErrorMessage = "جنسیت را وارد کنید")]
        [Display(Name = "جنسیت")]
        public bool Gender { get; set; }
        //public string Role { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}

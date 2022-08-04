using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Application.DTOs
{
   public class CourseDTO
    {
        public long ID { get; set; }
        public int CourseGroupCode { get; set; }
        public string TeacherID { get; set; }
        public byte ClassCode { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Title { get; set; }
        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CourseDescription { get; set; }
        public string TimeInWeek { get; set; }
        public DateTime? StartingDay { get; set; }

        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CoursePrice { get; set; }
        public string Keyword { get; set; }
        public string CourseImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

        /// <summary>
        /// مخصوص نمایش نام استاد
        /// </summary>
        public string TeacherName { get; set; }
    }
}

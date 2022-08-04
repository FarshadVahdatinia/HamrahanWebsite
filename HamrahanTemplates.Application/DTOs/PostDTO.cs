using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HamrahanTemplate.Application.DTOs
{
   public class PostDTO
    {
        [BindNever]
        public int ID { get; set; }

        public string ImagesLink { get; set; }
        [ValidateNever]
        public string PersonID { get; set; }

        [Required]
        [DisplayName("عنوان")]
        [StringLength(60, ErrorMessage = "متن اصلی باید حداکثر {2} کارکتر باشد ")]
        public string Topic { get; set; }

        [DisplayName("محتوای اصلی")]
        [Required(ErrorMessage ="حتما باید وارد شود")]
        [StringLength(10000,ErrorMessage ="متن اصلی باید حداقل {2} کارکتر باشد ", MinimumLength = 100)]
        public string Content { get; set; }
        public string Summary { get; set; }
      


        public DateTime Updated { get; set; }
        public DateTime Published { get; set; }
    }
}

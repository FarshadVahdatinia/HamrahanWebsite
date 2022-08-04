using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Application.DTOs
{
  public  class EducatinGradeDTO
    {
        [DisplayName("کد")]
        public byte Code { get; set; }
        
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DisplayName("میزان تحصیلات")]
        public string Grade { get; set; }
    }
}

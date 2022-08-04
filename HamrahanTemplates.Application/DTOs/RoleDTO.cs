using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Application.DTOs
{
    public class RoleDTO
    {
        public string Id { get; set; }

        //[Required(ErrorMessage = "لطفا { 0 } را وارد کنید")]
        [Display(Name = "نقش")]
        public string Name { get; set; }

        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

    }
}

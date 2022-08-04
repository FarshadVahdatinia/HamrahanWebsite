using Hamrahan.Models;
using Hamrahan.Models.course;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models
{
    public partial class StudentPayment
    {
        public long ID { get; set; }
        public string StudentID { get; set; }
        public long CourseID { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainAmount { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Student { get; set; }
    }
}

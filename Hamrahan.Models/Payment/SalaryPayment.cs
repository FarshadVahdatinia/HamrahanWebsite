using Hamrahan.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models
{
    public partial class SalaryPayment
    {
        public long ID { get; set; }
        public string EmployeeID { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RemainAmount { get; set; }

        public virtual Person Employee { get; set; }
    }
}

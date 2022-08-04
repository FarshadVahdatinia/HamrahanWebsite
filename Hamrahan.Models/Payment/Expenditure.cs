using System;
using System.Collections.Generic;

#nullable disable

namespace Hamrahan.Models
{
    public partial class Expenditure
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }
}

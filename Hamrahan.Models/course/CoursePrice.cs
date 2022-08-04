using System;



namespace Hamrahan.Models.course
{
    public partial class CoursePrice
    {
        public int Id { get; set; }
        public decimal MainPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public int SoldOutCount { get; set; }
        public DateTime DiscountStartingDate { get; set; }
        public DateTime DiscountEndingDate { get; set; }
        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}

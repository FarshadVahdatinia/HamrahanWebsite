using System;



namespace Hamrahan.Models.course
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }
        public string UserId { get; set; }
        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person User { get; set; }
    }
}

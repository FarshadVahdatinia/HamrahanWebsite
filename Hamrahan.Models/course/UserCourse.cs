using Hamrahan.Models.course;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Hamrahan.Models
{
    public partial class UserCourse
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public long CourseID { get; set; }
        public bool? IsRegistered { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        [ForeignKey("UserId")]
        public virtual Person User { get; set; }
    }
}

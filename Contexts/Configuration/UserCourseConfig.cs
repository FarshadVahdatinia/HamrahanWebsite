using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class UserCourseConfig : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> entity)
        {
            entity.ToTable("User_course", "Education");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.CourseID).HasColumnName("CourseID");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.CourseID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCourse_Course");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserCourses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student_c__Stude__5070F446");
        }
    }
}

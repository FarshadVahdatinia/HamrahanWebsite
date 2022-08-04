using Hamrahan.Models.course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {

            entity.ToTable("Course", "Education");
            //entity.HasQueryFilter(e => e.IsDeleted == true);


            entity.HasIndex(e => e.CategoryId, "IX_Course_CategoryId");

            entity.HasIndex(e => e.ClassCode, "IX_Course_ClassCode");

            entity.HasIndex(e => e.TeacherId, "IX_Course_TeacherID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CategoryId).HasDefaultValueSql("((0))");

            entity.Property(e => e.CourseDescription).HasMaxLength(100);

            entity.Property(e => e.CourseImageName).HasMaxLength(250);

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("(CONVERT([bit],(0)))");

            entity.Property(e => e.StartingDay).HasColumnType("date");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.Property(e => e.TimeInWeek)
                .IsRequired()
                .HasMaxLength(150)
                .HasDefaultValueSql("(N'')");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(60)
                .HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Course_CategoryId");

            entity.HasOne(d => d.ClassCodeNavigation)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassCode)
                .HasConstraintName("FK_Course_ClassCode");

            entity.HasOne(d => d.Teacher)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_Course_TeacherId");
        }
    }
}

using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class StudentPaymentConfig : IEntityTypeConfiguration<StudentPayment>
    {
        public void Configure(EntityTypeBuilder<StudentPayment> entity)
        {
            entity.ToTable("StudentPayment", "Payment");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.CourseID).HasColumnName("CourseID");

            entity.Property(e => e.PaidAmount).HasColumnType("decimal(15, 2)");

            entity.Property(e => e.RemainAmount).HasColumnType("decimal(15, 2)");

            entity.Property(e => e.StudentID).HasColumnName("StudentID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.StudentPayments)
                .HasForeignKey(d => d.CourseID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentPa__Cours__5535A963");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.StudentPayments)
                .HasForeignKey(d => d.StudentID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentPayment_Student");
        }
    }
}

using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class EducationGradeConfig : IEntityTypeConfiguration<EducationGrade>
    {
        public void Configure(EntityTypeBuilder<EducationGrade> entity)
        {
            entity.HasKey(e => e.Code)
                   .HasName("PK_Education");

            entity.ToTable("EducationGrade", "Education");

            entity.Property(e => e.Code).ValueGeneratedOnAdd();

            entity.Property(e => e.Grade)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

using Hamrahan.Models.course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.persistence.Configuration
{
    public class CoursePriceConfig : IEntityTypeConfiguration<CoursePrice>
    {
        public void Configure(EntityTypeBuilder<CoursePrice> entity)
        {
            entity.ToTable("CoursePrice");

            entity.HasIndex(e => e.CourseId, "IX_CoursePrice_CourseId");

            entity.Property(e => e.MainPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.SpecialPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("specialPrice");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.CoursePrices)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}

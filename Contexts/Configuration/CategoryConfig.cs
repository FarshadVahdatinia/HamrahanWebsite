using Hamrahan.Models;
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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category");

            entity.HasIndex(e => e.SubCategory, "IX_Category_SubCategory");

            entity.Property(e => e.Title).IsRequired();

            entity.HasOne(d => d.SubCategoryNavigation)
                .WithMany(p => p.InverseSubCategoryNavigation)
                .HasForeignKey(d => d.SubCategory);
        }
    }
}

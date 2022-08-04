using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.HasKey(e => e.Code)
                .HasName("PK_Class_Code");

            entity.ToTable("Class", "Education");

            entity.Property(e => e.Describtion).HasMaxLength(100);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

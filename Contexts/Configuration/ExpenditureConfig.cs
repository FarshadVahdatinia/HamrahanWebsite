using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class ExpenditureConfig : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> entity)
        {
            entity.ToTable("Expenditure", "Payment");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");

            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
        }
    }
}

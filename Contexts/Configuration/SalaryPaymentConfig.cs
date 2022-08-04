using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class SalaryPaymentConfig : IEntityTypeConfiguration<SalaryPayment>
    {
        public void Configure(EntityTypeBuilder<SalaryPayment> entity)
        {
            entity.ToTable("SalaryPayment", "Payment");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

            entity.Property(e => e.PaidAmount).HasColumnType("decimal(15, 2)");

            entity.Property(e => e.RemainAmount).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.SalaryPayments)
                .HasForeignKey(d => d.EmployeeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalaryPayment_Employee");
        }
    }
}

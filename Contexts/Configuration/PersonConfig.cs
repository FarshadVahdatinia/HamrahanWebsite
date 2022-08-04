
using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.Property(e => e.TelePhone).HasColumnName("TelePhone");
            entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
            entity.Property(e => e.Email).HasMaxLength(256);

            entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[Birthdate],getdate()))", false);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(101)
                .HasComputedColumnSql("(([FirstName]+'')+[Lastname])", false);
            entity.Property(a => a.RegisterDate).HasComputedColumnSql("(getdate())", false);
            entity.HasOne(d => d.EducationGradeNavigation)
                 .WithMany(p => p.People)
                 .HasForeignKey(d => d.EducationGradecode);
        }
    }
}

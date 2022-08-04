using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class KeywordConfig : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> entity)
        {
            entity.ToTable("Keyword", "Weblog");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100).IsUnicode(true);
        }
    }
}

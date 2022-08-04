using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.ToTable("Post", "Weblog");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ImagesLink).HasColumnName("ImagesLink");
            entity.Property(e => e.Topic)
                .IsRequired()
                .HasMaxLength(150).IsUnicode(true);
            entity.Property(e => e.Content).IsRequired().IsUnicode(true);
            entity.Property(a => a.Published).HasComputedColumnSql("(getdate())", false);
            entity.Property(a => a.Updated).HasColumnName("Updated");
            entity.Property(a => a.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Topic)
                   .IsRequired()
                   .HasMaxLength(150)
                   .HasDefaultValueSql("(N'')");
            entity.HasOne(d => d.Person)
                .WithMany(p => p.PersonPosts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Post");
            entity.Property(s => s.Summary).HasColumnName("Summary");
            entity.Property(i => i.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);

        }
    }
}

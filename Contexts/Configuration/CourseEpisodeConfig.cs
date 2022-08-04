using Hamrahan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamrahanTemplate.persistence.Configuration
{
    internal class CourseEpisodeConfig : IEntityTypeConfiguration<CourseEpisode>
    {
        public void Configure(EntityTypeBuilder<CourseEpisode> entity)
        {
            entity.ToTable("CourseEpisode", "Education");
            entity.HasOne(d => d.Course)
                .WithMany(p => p.CourseEpisodes)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseEpisode_Course");
        }
    }
}

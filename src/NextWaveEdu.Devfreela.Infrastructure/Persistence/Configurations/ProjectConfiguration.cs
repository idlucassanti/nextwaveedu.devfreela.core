using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextWaveEdu.Devfreela.Domain.Entities;

namespace NextWaveEdu.Devfreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Freelancer)
                .WithMany(y => y.FreelaProjects)
                .HasForeignKey(x => x.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Owner)
                .WithMany(y => y.OwnerProjects)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

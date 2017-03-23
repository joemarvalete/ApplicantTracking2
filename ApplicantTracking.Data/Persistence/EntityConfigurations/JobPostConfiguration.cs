using System.Data.Entity.ModelConfiguration;
using ApplicantTracking.Data.Core.Domain;

namespace ApplicantTracking.Data.Persistence.EntityConfigurations
{
    public class JobPostConfiguration : EntityTypeConfiguration<JobPost>
    {
        public JobPostConfiguration()
        {
            HasMany(c => c.Applicants)
                .WithMany(t => t.JobPosts)
                .Map(m =>
                {
                    m.ToTable("JobPostApplicants");
                    m.MapLeftKey("JobPostId");
                    m.MapRightKey("ApplicantId");
                });
        }
    }
}

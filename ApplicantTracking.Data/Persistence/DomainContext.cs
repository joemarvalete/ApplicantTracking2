using System.Data.Entity;
using ApplicantTracking.Data.Core;
using ApplicantTracking.Data.Core.Domain;
using ApplicantTracking.Data.Persistence.EntityConfigurations;

namespace ApplicantTracking.Data.Persistence
{
    public class DomainContext : DbContext, IDbContext
    {
        public DomainContext()
            : base("name=DomainContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<JobPost> JobPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JobPostConfiguration());
        }
    }
}

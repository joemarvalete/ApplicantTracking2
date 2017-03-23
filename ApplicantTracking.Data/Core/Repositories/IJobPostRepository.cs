using System.Collections.Generic;
using ApplicantTracking.Data.Core.Domain;

namespace ApplicantTracking.Data.Core.Repositories
{
    public interface IJobPostRepository : IRepository<JobPost>
    {
        IEnumerable<JobPost> GetJobPosts();
        IEnumerable<JobPost> GetJobPostsWhere(string args);
        JobPost GetJobPostWithApplicant(int id);
        IEnumerable<JobPost> GetJobPostsWithApplicants();
    }
}

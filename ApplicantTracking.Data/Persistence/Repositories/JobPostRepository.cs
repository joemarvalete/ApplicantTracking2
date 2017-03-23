using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicantTracking.Data.Core;
using ApplicantTracking.Data.Core.Domain;
using ApplicantTracking.Data.Core.Repositories;

namespace ApplicantTracking.Data.Persistence.Repositories
{
    public class JobPostRepository : Repository<JobPost>, IJobPostRepository
    {
        public JobPostRepository(IDbContext context)
            : base(context)
        {

        }

        public IEnumerable<JobPost> GetJobPosts()
        {
            return Entities.OrderByDescending(o => o.DateCreated).ToList();
        }

        public IEnumerable<JobPost> GetJobPostsWhere(string args)
        {
            return Entities.Include(c => c.Applicants).Where(x => x.JobTitle.Contains(args) || x.Description.Contains(args)).ToList();
        }

        public JobPost GetJobPostWithApplicant(int id)
        {
            return Entities.Include(c => c.Applicants).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<JobPost> GetJobPostsWithApplicants()
        {
            return Entities.Include(c => c.Applicants).ToList();
        }
    }
}

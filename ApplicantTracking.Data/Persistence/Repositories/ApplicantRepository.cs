using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicantTracking.Data.Core;
using ApplicantTracking.Data.Core.Domain;
using ApplicantTracking.Data.Core.Repositories;

namespace ApplicantTracking.Data.Persistence.Repositories
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return Entities.OrderByDescending(o => o.AppliedDate).ToList();
        }
    }
}

using System.Collections.Generic;
using ApplicantTracking.Data.Core.Domain;

namespace ApplicantTracking.Data.Core.Repositories
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        IEnumerable<Applicant> GetApplicants();
    }
}

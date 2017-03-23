using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicantTracking.Data.Core.Repositories;

namespace ApplicantTracking.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository Applicants { get; }
        IJobPostRepository JobPosts { get; }
        int SaveChanges();
    }
}

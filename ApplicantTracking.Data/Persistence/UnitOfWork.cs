using ApplicantTracking.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicantTracking.Data.Core.Repositories;
using ApplicantTracking.Data.Persistence.Repositories;

namespace ApplicantTracking.Data.Persistence
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            Applicants = new ApplicantRepository(_context);
            JobPosts = new JobPostRepository(_context);
        }

        public IApplicantRepository Applicants { get; private set; }
        public IJobPostRepository JobPosts { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

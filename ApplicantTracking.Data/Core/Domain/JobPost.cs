using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracking.Data.Core.Domain
{
    public class JobPost
    {
        public JobPost()
        {
            Applicants = new HashSet<Applicant>();
        }

        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsClosed { get; set; }

    }
}

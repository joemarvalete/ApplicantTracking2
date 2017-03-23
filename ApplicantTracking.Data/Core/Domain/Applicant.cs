using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracking.Data.Core.Domain
{
    public class Applicant
    {
        public Applicant()
        {
            JobPosts = new HashSet<JobPost>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string HiringStatus { get; set; }

        public virtual ICollection<JobPost> JobPosts { get; set; }

        public DateTime AppliedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicantTracking.Data.Core.Domain;

namespace ApplicantTracking.Models
{
    public class JobPostModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }

        public double Withdraw { get; set; }
        public double Interviewed { get; set; }
        public double ImmediateRejection { get; set; }
        public double Hired { get; set; }
        public double New { get; set; }
        public int TotalApplications { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsClosed { get; set; }
    }
}
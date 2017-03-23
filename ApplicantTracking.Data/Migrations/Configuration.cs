using System.Collections.ObjectModel;
using ApplicantTracking.Data.Core.Domain;

namespace ApplicantTracking.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicantTracking.Data.Persistence.DomainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicantTracking.Data.Persistence.DomainContext context)
        {
            #region Add JobPost

            var applicants = new Dictionary<string, Applicant>
            {
                {"John Doe", new Applicant { Id = 1, FullName = "John Doe", JobTitle = "System Analyst", HiringStatus = "Hired", AppliedDate = DateTime.Parse("03/20/2017 8:00 AM") } },
                {"Sarah Bryan", new Applicant { Id = 2, FullName = "Sarah Bryan", JobTitle = "Senior Web Developer", HiringStatus = "Hired", AppliedDate = DateTime.Parse("03/20/2017 10:00 AM") } },
                {"Larry Donovan", new Applicant { Id = 3, FullName = "Larry Donovan", JobTitle = "Quality Assurance Analyst", HiringStatus = "Hired", AppliedDate = DateTime.Parse("03/20/2017 10:00 AM") } },
                {"Raymond Pierce", new Applicant { Id = 4, FullName = "Raymond Pierce", JobTitle = "Software Engineer", HiringStatus = "Withdraw", AppliedDate = DateTime.Parse("03/20/2017 11:00 AM") } },
                {"Madeline Dube", new Applicant { Id = 5, FullName = "Madeline Dube", JobTitle = "Software Engineer", HiringStatus = "Immediate Rejection", AppliedDate = DateTime.Parse("03/21/2017 8:00 AM") } },
                {"Sung Wallace", new Applicant { Id = 6, FullName = "Sung Wallace", JobTitle = "Software Architect", HiringStatus = "Interview", AppliedDate = DateTime.Parse("03/21/2017 9:00 AM") } },
                {"Raul Williams", new Applicant { Id = 7, FullName = "Raul Williams", JobTitle = "Network Administrator", HiringStatus = "Immediate Rejection", AppliedDate = DateTime.Parse("03/21/2017 11:00 AM") } },
                {"Mellissa Ludwick", new Applicant { Id = 8, FullName = "Mellissa Ludwick", JobTitle = "Quality Assurance Analyst", HiringStatus = "Interview", AppliedDate = DateTime.Parse("03/21/2017 1:00 PM") } },
                {"Kathleen Hopkins", new Applicant { Id = 9, FullName = "Kathleen Hopkins", JobTitle = "Senior Web Developer", HiringStatus = "Interview", AppliedDate = DateTime.Parse("03/21/2017 3:00 PM") } },
                {"Fredrick Irwin", new Applicant { Id = 10, FullName = "Fredrick Irwin", JobTitle = "Software Engineer", HiringStatus = "Interview", AppliedDate = DateTime.Parse("03/21/2017 5:00 PM") } },
                {"Melaine Coney", new Applicant { Id = 11, FullName = "Melaine Coney", JobTitle = "Quality Assurance Analyst", HiringStatus = "Immediate rejection", AppliedDate = DateTime.Parse("03/22/2017 8:00 AM") } },
                {"Robert Schweitzer", new Applicant { Id = 12, FullName = "Robert Schweitzer", JobTitle = "Web Designer", HiringStatus = "Interview", AppliedDate = DateTime.Parse("03/22/2017 9:00 AM") } },
                {"Kevin Moore", new Applicant { Id = 13, FullName = "Kevin Moore", JobTitle = "System Analyst", HiringStatus = "New", AppliedDate = DateTime.Parse("03/22/2017 11:00 AM") } },
                {"Lloyd Bray", new Applicant { Id = 14, FullName = "Lloyd Bray", JobTitle = "Web Designer", HiringStatus = "Hired", AppliedDate = DateTime.Parse("03/22/2017 1:00 PM") } },
                {"Joshua Harris", new Applicant { Id = 15, FullName = "Joshua Harris", JobTitle = "Network Administrator", HiringStatus = "New", AppliedDate = DateTime.Parse("03/22/2017 3:00 PM") } }
            };
            foreach (var applicant in applicants.Values)
                context.Applicants.AddOrUpdate(t => t.Id, applicant);
            #endregion

            #region Add JobPost

            var jobPosts = new List<JobPost>
            {
                new JobPost { JobTitle = "System Analyst", Description = "System Analyst", DateCreated = DateTime.Parse("03/13/2017 4:00 PM"), IsClosed = true, 
                    Applicants = new Collection<Applicant>(){
                        applicants["John Doe"],
                        applicants["Kevin Moore"]
                    }},
                new JobPost { JobTitle = "Senior Web Developer", Description = "Senior Web Developer", DateCreated = DateTime.Parse("03/13/2017 6:00 PM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Sarah Bryan"],
                        applicants["Kathleen Hopkins"]
                    }},
                new JobPost { JobTitle = "Quality Assurance Analyst", Description = "Quality Assurance Analyst", DateCreated = DateTime.Parse("03/15/2017 9:00 AM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Larry Donovan"],
                        applicants["Mellissa Ludwick"],
                        applicants["Melaine Coney"]
                    }},
                new JobPost { JobTitle = "Software Engineer", Description = "Software Engineer", DateCreated = DateTime.Parse("03/17/2017 9:00 AM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Raymond Pierce"],
                        applicants["Madeline Dube"],
                        applicants["Fredrick Irwin"]
                    }},
                new JobPost { JobTitle = "Software Architect", Description = "Software Architect", DateCreated = DateTime.Parse("03/18/2017 10:00 AM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Sung Wallace"]
                    }},
                new JobPost { JobTitle = "Network Administrator", Description = "Network Administrator", DateCreated = DateTime.Parse("03/19/2017 8:00 AM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Raul Williams"],
                        applicants["Joshua Harris"]
                    }},
                new JobPost { JobTitle = "Web Designer", Description = "Web Designer", DateCreated = DateTime.Parse("03/20/2017 10:00 AM"), IsClosed = false, 
                    Applicants = new Collection<Applicant>(){
                        applicants["Robert Schweitzer"],
                        applicants["Lloyd Bray"]
                    }}
            };

            foreach (var jobPost in jobPosts)
                context.JobPosts.AddOrUpdate(c => c.Id, jobPost);

            #endregion



        }
    }
}

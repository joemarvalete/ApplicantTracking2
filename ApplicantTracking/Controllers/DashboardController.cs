using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicantTracking.Data.Core;
using ApplicantTracking.Data.Core.Domain;
using ApplicantTracking.Data.Core.Repositories;
using ApplicantTracking.Models;

namespace ApplicantTracking.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IJobPostRepository _jobPostRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IJobPostRepository jobPostRepo, IUnitOfWork unitOfWork)
        {
            _jobPostRepo = jobPostRepo;
            _unitOfWork = unitOfWork;
        }

        // GET: Dashboard
        public ActionResult Index(string search)
        {
            IEnumerable<JobPost> _jobPost = null;

            _jobPost = !String.IsNullOrEmpty(search) ? _jobPostRepo.GetJobPostsWhere(search) : _jobPostRepo.GetJobPostsWithApplicants();
            
            var model = _jobPost.Select(s => new JobPostModel
            {
                DateCreated = s.DateCreated,
                Description = s.Description,
                JobTitle = s.JobTitle,
                Id = s.Id,
                IsClosed = s.IsClosed,
                Withdraw = s.Applicants.Count(x => x.HiringStatus == "Withdraw"),
                ImmediateRejection = s.Applicants.Count(x => x.HiringStatus == "Immediate Rejection"),
                Interviewed = s.Applicants.Count(x => x.HiringStatus == "Interview"),
                Hired = s.Applicants.Count(x => x.HiringStatus == "Hired"),
                New = s.Applicants.Count(x => x.HiringStatus == "New"),
                TotalApplications = s.Applicants.Count()
            });
            return View(model);
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            var getDetails = _jobPostRepo.GetJobPostWithApplicant(id);
            var model = new JobPostModel
            {
                DateCreated = getDetails.DateCreated,
                Description = getDetails.Description,
                JobTitle = getDetails.JobTitle,
                Id = getDetails.Id,
                IsClosed = getDetails.IsClosed,
                Withdraw = getDetails.Applicants.Count(x => x.HiringStatus == "Withdraw"),
                ImmediateRejection = getDetails.Applicants.Count(x => x.HiringStatus == "Immediate Rejection"),
                Interviewed = getDetails.Applicants.Count(x => x.HiringStatus == "Interview"),
                Hired = getDetails.Applicants.Count(x => x.HiringStatus == "Hired"),
                New = getDetails.Applicants.Count(x => x.HiringStatus == "New"),
                TotalApplications = getDetails.Applicants.Count(),            
                Applicants = getDetails.Applicants
            };           
            return View(model);
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Post Job";
            
            return View("FormView", new JobPostFormModel{ IsEdit = false });
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Job";

            var getJob = _jobPostRepo.Get(id);

            return View("FormView",
                new JobPostFormModel {IsEdit = true, Description = getJob.Description, JobTitle = getJob.JobTitle});
        }

        // POST: Dashboard/Submit
        [HttpPost]
        public ActionResult Submit(JobPostFormModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsEdit)
                {
                    var getJob = _unitOfWork.JobPosts.Get(model.Id);
                    getJob.Description = model.Description;
                    getJob.JobTitle = model.JobTitle;
                }
                else
                {
                    _unitOfWork.JobPosts.Add(new JobPost
                    {
                        DateCreated = DateTime.Now,
                        Description = model.Description,
                        JobTitle = model.JobTitle,
                        IsClosed = false
                    });
                }
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Title = model.IsEdit? "Edit Job": "Post Job";
            return View("FormView");
        }
    }
}
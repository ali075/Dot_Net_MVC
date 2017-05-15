using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.BLL;
using JobPortal.Models;
using Microsoft.AspNet.Identity;


namespace JobPortal.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager();
        

        
        public ActionResult EmployerJobPost()
        {
            var session = Session["user"] as Employer;

            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult EmployerJobPost(JobInfo jobInfo)
        {

            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            int id = session.EmployerID;
            string message = jobManager.InsertJobInfo(jobInfo, id);
            ViewBag.message = message;
            return View();
        }

        public ActionResult ViewAllPostedJobs()
        {
            List<JobInfo> jobInfoList = jobManager.GetJobInfo();

            ViewBag.jobList = jobInfoList;
            return View();
        }

        public ActionResult ViewEmployerPostedJobs()
        {

            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            int id = session.EmployerID;

            List<JobInfo> employerJobInfoList = jobManager.GetEmployerJobInfo(id);
            ViewBag.employerJobList = employerJobInfoList;

            return View();
        }



        public ActionResult ViewDetailPostedJobs(int id)
        {
            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);

            ViewBag.jobDetails = jobInfoList;
            return View();
        }

        public ActionResult EmployerEditPostedJobs(int id)
        {
            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);
            ViewBag.jobDetails = jobInfoList;

            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult EmployerEditPostedJobs(JobInfo jobInfo, int id)
        {
            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            string message = jobManager.UpdateJobInfo(jobInfo, id);

            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);
            ViewBag.jobDetails = jobInfoList;

            ViewBag.message = message;
            return View();
        }

        public ActionResult ApplyJob(int id)
        {
            var session = Session["user"] as Seeker;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);

            ViewBag.jobInfo = jobInfoList;

            ViewBag.message = "";


            return View();
        }

        [HttpPost]
        public ActionResult ApplyJob(AppliedJob appliedJob, int id)
        {
            var session = Session["user"] as Seeker;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            int seekerID = session.SeekerID;

            List<JobInfo> jobInfoList = jobManager.GetDetailJobInfo(id);

            ViewBag.jobInfo = jobInfoList;

            string message = jobManager.InsertJobApplication(appliedJob, id, seekerID);

            ViewBag.message = message;
            return View();
        }

        public ActionResult SeekerAppliedJobs()
        {
            var session = Session["user"] as Seeker;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }
            int seekerID = session.SeekerID;

            List<AppliedJob> appliedJobList = jobManager.GetUserAppliedJobDetails(seekerID);

            ViewBag.jobDetails = appliedJobList;
            
            return View();
        }

        public ActionResult ViewAppliedCandidates(int id)
        {
            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            List<AppliedJob> appliedCandidatesList = jobManager.GetAppliedCandidates(id);

            ViewBag.candidateList = appliedCandidatesList;

            return View();
        }

        public ActionResult ViewAppliedCandidatesDetails(int id)
        {
            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }

            List<AppliedJob> appliedCandidatesList = jobManager.GetAppliedCandidatesDetails(id);

            ViewBag.candidateList = appliedCandidatesList;

            return View();
        }

        public ActionResult DownloadResume(int id, string name, int applyId)
        {
            var session = Session["user"] as Employer;
            if (session == null)
            {
                return RedirectToAction("LoginAccount", "Login");
            }


            var fileName = name + " Resume" + id + ".pdf";

            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/App_Data/Resume/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles(id + ".pdf");

            if (fileNames.Length == 0)
            {
                //ViewBag.message = "Resume was not uploaded..";
                return RedirectToAction("ViewAppliedCandidatesDetails", "Job", new { id = applyId });
                

            }
            else
            {
                var data = File("~/App_Data/Resume/" + id + ".pdf", System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                return data;
            }

        }

    }
}
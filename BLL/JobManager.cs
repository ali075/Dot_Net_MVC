using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class JobManager
    {
        JobGetway jobGetway = new JobGetway();

        public string InsertJobInfo(JobInfo jobInfo, int id)
        {
            string message = "Job posting failed";

            int isInserted = jobGetway.InsertJobInfo(jobInfo, id);
            if (isInserted > 0)
            {
                message = "Job posted Successfully";
            }
            return message;
        }

        public List<JobInfo> GetJobInfo ()
        {
            List<JobInfo> jobInfoList = jobGetway.GetJobInfo();

            return jobInfoList;
        }

        public List<JobInfo> GetDetailJobInfo(int id)
        {
            List<JobInfo> jobInfoList = jobGetway.GetDetailJobInfo(id);

            return jobInfoList;
        }

        public string UpdateJobInfo(JobInfo jobInfo, int id)
        {
            string message = "Job updating  failed";

            int isInserted = jobGetway.UpdateJobInfo(jobInfo, id);
            if (isInserted > 0)
            {
                message = "Job Updated Successfully";
            }
            return message;
        }

        public List<JobInfo> GetEmployerJobInfo(int id)
        {
            List<JobInfo> jobInfoList = jobGetway.GetEmployerJobInfo(id);

            return jobInfoList;
        }

        public string InsertJobApplication(AppliedJob appliedJob, int jobID, int seekerID)
        {
            string message = "Applied Failed";

            bool isAlreadyApplied = jobGetway.IsAlreadyApplied(appliedJob, jobID, seekerID);
            if (isAlreadyApplied)
            {
                message = "You already applied for this job";
                return message;
            }
            else
            {
                int isInserted = jobGetway.InsertJobApplication(appliedJob, jobID, seekerID);
                if (isInserted > 0)
                {
                    message = "Applied Successfully";
                }
                return message;
            }

        }

        public List<AppliedJob> GetUserAppliedJobDetails(int seekerID)
        {
            List<AppliedJob> appliedJobslist = jobGetway.GetUserAppliedJobDetails(seekerID);
            return appliedJobslist;
        }

        public List<AppliedJob> GetAppliedCandidates(int jobID)
        {
            List<AppliedJob> appliedcandidatesList = jobGetway.GetAppliedCandidates(jobID);
            return appliedcandidatesList;
        }

        public List<AppliedJob> GetAppliedCandidatesDetails(int id)
        {
            List<AppliedJob> appliedcandidatesList = jobGetway.GetAppliedCandidatesDetails(id);
            return appliedcandidatesList;
        }
    }
}
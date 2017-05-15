using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class JobGetway
    {
        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public int InsertJobInfo(JobInfo jobInfo, int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO JobInfo (JobTitle, JobDescription, JobNature, EducationalRequirements, ExperienceRequirements, AdditionalRequirements, NoOfVacancies, SalaryRange, OtherBenefit, EmployerID, PublishTime, ApplicationDeadline) VALUES (@jobTitle, @jobDescription, @jobNature, @educationalRequirements, @experienceRequirements, @additionalRequirements, @noOfVacancies, @salaryRange, @otherBenefit, @employerID, @publishTime, @applicationDeadline)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("jobTitle", SqlDbType.VarChar);
            command.Parameters["jobTitle"].Value = jobInfo.JobTitle;

            command.Parameters.Add("jobDescription", SqlDbType.VarChar);
            command.Parameters["jobDescription"].Value = jobInfo.JobDescription;

            command.Parameters.Add("jobNature", SqlDbType.VarChar);
            command.Parameters["jobNature"].Value = jobInfo.JobNature;

            command.Parameters.Add("educationalRequirements", SqlDbType.VarChar);
            command.Parameters["educationalRequirements"].Value = jobInfo.EducationalRequirements;

            command.Parameters.Add("experienceRequirements", SqlDbType.VarChar);
            command.Parameters["experienceRequirements"].Value = jobInfo.ExperienceRequirements;

            command.Parameters.Add("additionalRequirements", SqlDbType.VarChar);
            command.Parameters["additionalRequirements"].Value = jobInfo.AdditionalRequirements;

            command.Parameters.Add("noOfVacancies", SqlDbType.Int);
            command.Parameters["noOfVacancies"].Value = jobInfo.NoOfVacancies;

            command.Parameters.Add("salaryRange", SqlDbType.VarChar);
            command.Parameters["salaryRange"].Value = jobInfo.SalaryRange;

            command.Parameters.Add("otherBenefit", SqlDbType.VarChar);
            command.Parameters["otherBenefit"].Value = jobInfo.OtherBenefit;

            command.Parameters.Add("employerID", SqlDbType.Int);
            command.Parameters["employerID"].Value = id;

            command.Parameters.Add("publishTime", SqlDbType.DateTime);
            command.Parameters["publishTime"].Value = DateTime.Today;

            command.Parameters.Add("applicationDeadline", SqlDbType.DateTime);
            command.Parameters["applicationDeadline"].Value = jobInfo.ApplicationDeadline;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public List<JobInfo> GetJobInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM JobInfo INNER JOIN EmployersInfo ON JobInfo.EmployerID = EmployersInfo.EmployerID and JobInfo.ApplicationDeadline >= (@currentDate)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("currentDate", SqlDbType.DateTime);
            command.Parameters["currentDate"].Value = DateTime.Today;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            List<JobInfo> jobInfoList = new List<JobInfo>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["JobID"]);
                string companyName = reader["CompanyName"].ToString();
                string jobTitle = reader["JobTitle"].ToString();
                string jobDescription = reader["JobDescription"].ToString();
                string jobNature = reader["JobNature"].ToString();
                string educationalRequirements = reader["EducationalRequirements"].ToString();
                string experienceRequirements = reader["ExperienceRequirements"].ToString();
                string additionalRequirements = reader["AdditionalRequirements"].ToString();
                int noOfVacancies = Convert.ToInt32(reader["NoOfVacancies"]);
                string salaryRange = reader["SalaryRange"].ToString();
                string otherBenefit = reader["OtherBenefit"].ToString();
                DateTime applicationDeadline = Convert.ToDateTime(reader["ApplicationDeadline"]);
                DateTime publishTime = Convert.ToDateTime(reader["PublishTime"]);

                JobInfo jobInfo = new JobInfo(id, jobTitle, jobDescription, jobNature, educationalRequirements, experienceRequirements, additionalRequirements, noOfVacancies, salaryRange, otherBenefit, applicationDeadline, publishTime, companyName);

                jobInfoList.Add(jobInfo);
            }
            return jobInfoList;
        }

        public List<JobInfo> GetDetailJobInfo(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM JobInfo INNER JOIN EmployersInfo ON JobInfo.EmployerID=EmployersInfo.EmployerID and JobInfo.JobID = " + id;
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<JobInfo> jobInfoList = new List<JobInfo>();

            while (reader.Read())
            {

                string companyName = reader["CompanyName"].ToString();
                string jobTitle = reader["JobTitle"].ToString();
                string jobDescription = reader["JobDescription"].ToString();
                string jobNature = reader["JobNature"].ToString();
                string educationalRequirements = reader["EducationalRequirements"].ToString();
                string experienceRequirements = reader["ExperienceRequirements"].ToString();
                string additionalRequirements = reader["AdditionalRequirements"].ToString();
                int noOfVacancies = Convert.ToInt32(reader["NoOfVacancies"]);
                string salaryRange = reader["SalaryRange"].ToString();
                string otherBenefit = reader["OtherBenefit"].ToString();
                DateTime applicationDeadline = Convert.ToDateTime(reader["ApplicationDeadline"]);
                DateTime publishTime = Convert.ToDateTime(reader["PublishTime"]);

                JobInfo jobInfo = new JobInfo(jobTitle, jobDescription, jobNature, educationalRequirements, experienceRequirements, additionalRequirements, noOfVacancies, salaryRange, otherBenefit, applicationDeadline, publishTime, companyName);

                jobInfoList.Add(jobInfo);
            }
            return jobInfoList;

        }

        public int UpdateJobInfo(JobInfo jobInfo, int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE JobInfo SET JobTitle = (@jobTitle), JobDescription = (@jobDescription), JobNature = (@jobNature), EducationalRequirements = (@educationalRequirements), ExperienceRequirements = (@experienceRequirements), AdditionalRequirements = (@additionalRequirements), NoOfVacancies = (@noOfVacancies), SalaryRange = (@salaryRange), OtherBenefit = (@otherBenefit), ApplicationDeadline = (@applicationDeadline) WHERE JobID = (@jobID)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("jobTitle", SqlDbType.VarChar);
            command.Parameters["jobTitle"].Value = jobInfo.JobTitle;

            command.Parameters.Add("jobDescription", SqlDbType.VarChar);
            command.Parameters["jobDescription"].Value = jobInfo.JobDescription;

            command.Parameters.Add("jobNature", SqlDbType.VarChar);
            command.Parameters["jobNature"].Value = jobInfo.JobNature;

            command.Parameters.Add("educationalRequirements", SqlDbType.VarChar);
            command.Parameters["educationalRequirements"].Value = jobInfo.EducationalRequirements;

            command.Parameters.Add("experienceRequirements", SqlDbType.VarChar);
            command.Parameters["experienceRequirements"].Value = jobInfo.ExperienceRequirements;

            command.Parameters.Add("additionalRequirements", SqlDbType.VarChar);
            command.Parameters["additionalRequirements"].Value = jobInfo.AdditionalRequirements;

            command.Parameters.Add("noOfVacancies", SqlDbType.Int);
            command.Parameters["noOfVacancies"].Value = jobInfo.NoOfVacancies;

            command.Parameters.Add("salaryRange", SqlDbType.VarChar);
            command.Parameters["salaryRange"].Value = jobInfo.SalaryRange;

            command.Parameters.Add("otherBenefit", SqlDbType.VarChar);
            command.Parameters["otherBenefit"].Value = jobInfo.OtherBenefit;

            command.Parameters.Add("applicationDeadline", SqlDbType.DateTime);
            command.Parameters["applicationDeadline"].Value = jobInfo.ApplicationDeadline;

            command.Parameters.Add("jobID", SqlDbType.Int);
            command.Parameters["jobID"].Value = id;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }

        public List<JobInfo> GetEmployerJobInfo(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM JobInfo INNER JOIN EmployersInfo ON JobInfo.EmployerID = EmployersInfo.EmployerID and EmployersInfo.EmployerID = " + id;
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<JobInfo> jobInfoList = new List<JobInfo>();

            while (reader.Read())
            {
                int jobId = Convert.ToInt32(reader["JobID"]);
                string companyName = reader["CompanyName"].ToString();
                string jobTitle = reader["JobTitle"].ToString();
                string jobDescription = reader["JobDescription"].ToString();
                string jobNature = reader["JobNature"].ToString();
                string educationalRequirements = reader["EducationalRequirements"].ToString();
                string experienceRequirements = reader["ExperienceRequirements"].ToString();
                string additionalRequirements = reader["AdditionalRequirements"].ToString();
                int noOfVacancies = Convert.ToInt32(reader["NoOfVacancies"]);
                string salaryRange = reader["SalaryRange"].ToString();
                string otherBenefit = reader["OtherBenefit"].ToString();
                DateTime applicationDeadline = Convert.ToDateTime(reader["ApplicationDeadline"]);
                DateTime publishTime = Convert.ToDateTime(reader["PublishTime"]);

                JobInfo jobInfo = new JobInfo(jobId, jobTitle, jobDescription, jobNature, educationalRequirements, experienceRequirements, additionalRequirements, noOfVacancies, salaryRange, otherBenefit, applicationDeadline, publishTime, companyName);

                jobInfoList.Add(jobInfo);
            }
            return jobInfoList;
        }

        public int InsertJobApplication(AppliedJob appliedJob, int jobID, int seekerID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO AppliedJobInfo (SeekerID, JobID, CoverLetter, AppliedTime) VALUES (@seekerID, @jobID, @coverLetter, @appliedTime)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("SeekerID", SqlDbType.Int);
            command.Parameters["SeekerID"].Value = seekerID;

            command.Parameters.Add("JobID", SqlDbType.Int);
            command.Parameters["JobID"].Value = jobID;

            command.Parameters.Add("coverLetter", SqlDbType.VarChar);
            command.Parameters["coverLetter"].Value = appliedJob.CoverLetter;

            command.Parameters.Add("appliedTime", SqlDbType.DateTime);
            command.Parameters["appliedTime"].Value = DateTime.Today;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }


        public bool IsAlreadyApplied(AppliedJob appliedJob, int jobID, int seekerID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from AppliedJobInfo where SeekerID =(@seekerID) and JobID = (@jobID)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("seekerID", SqlDbType.Int);
            command.Parameters["seekerID"].Value = seekerID;

            command.Parameters.Add("jobID", SqlDbType.Int);
            command.Parameters["jobID"].Value = jobID;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AppliedJob> GetUserAppliedJobDetails (int seekerId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from JobSeekersInfo inner join AppliedJobInfo  on JobSeekersInfo.SeekerID = AppliedJobInfo.SeekerID inner join JobInfo on JobInfo.JobID = AppliedJobInfo.JobID inner join EmployersInfo on EmployersInfo.EmployerID = JobInfo.EmployerID and JobSeekersInfo.SeekerID = " + seekerId;
                
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<AppliedJob> appliedJobslist = new List<AppliedJob>();

            while (reader.Read())
            {
                int appliedJobID = Convert.ToInt32(reader["AppliedJobID"]);
                int jobID = Convert.ToInt32(reader["JobID"]);
                string seekerName = reader["Name"].ToString();
                string seekerEmail = reader["Email"].ToString();
                string coverLetter = reader["CoverLetter"].ToString();
                DateTime appliedTime = Convert.ToDateTime(reader["AppliedTime"]);
                string jobTitle = reader["JobTitle"].ToString();
                string jobDescription = reader["JobDescription"].ToString();
                string jobNature = reader["JobNature"].ToString();
                string educationalRequirements = reader["EducationalRequirements"].ToString();
                string experienceRequirements = reader["ExperienceRequirements"].ToString();
                string additionalRequirements = reader["AdditionalRequirements"].ToString();
                int noOfVacancies = Convert.ToInt32(reader["NoOfVacancies"]);
                string salaryRange = reader["SalaryRange"].ToString();
                string otherBenefit = reader["OtherBenefit"].ToString();
                DateTime applicationDeadline = Convert.ToDateTime(reader["ApplicationDeadline"]);
                DateTime publishTime = Convert.ToDateTime(reader["PublishTime"]);
                string companyName = reader["CompanyName"].ToString();
                string companyEmail = reader["ContactPersonEmail"].ToString();
                

                AppliedJob appliedJob = new AppliedJob(appliedJobID, jobID, seekerName, seekerEmail, coverLetter, appliedTime, jobTitle, jobDescription, jobNature, educationalRequirements,  experienceRequirements,  additionalRequirements,  noOfVacancies,  salaryRange, otherBenefit, applicationDeadline, publishTime, companyName,  companyEmail);

                appliedJobslist.Add(appliedJob);
            }
            return appliedJobslist;
        }

        public List<AppliedJob> GetAppliedCandidates(int jobID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Gender inner join JobSeekersInfo on Gender.ID = JobSeekersInfo.GenderID inner join AppliedJobInfo on JobSeekersInfo.SeekerID = AppliedJobInfo.SeekerID and AppliedJobInfo.JobID = " + jobID;

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<AppliedJob> appliedCandidateslist = new List<AppliedJob>();

            while (reader.Read())
            {
                int appliedJobID = Convert.ToInt32(reader["AppliedJobID"]);
                int seekerID = Convert.ToInt32(reader["SeekerID"]);
                string seekerName = reader["Name"].ToString();
                string seekerEmail = reader["Email"].ToString();
                string seekerAddress = reader["Address"].ToString();
                string gender = reader["Type"].ToString();
                string coverLetter = reader["CoverLetter"].ToString();
                DateTime appliedTime = Convert.ToDateTime(reader["AppliedTime"]);


                AppliedJob appliedJob = new AppliedJob(appliedJobID, seekerID, seekerName, seekerEmail, seekerAddress, gender, coverLetter, appliedTime);

                appliedCandidateslist.Add(appliedJob);
            }
            return appliedCandidateslist;
        }

        public List<AppliedJob> GetAppliedCandidatesDetails(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Gender inner join JobSeekersInfo on Gender.ID = JobSeekersInfo.GenderID inner join AppliedJobInfo on JobSeekersInfo.SeekerID = AppliedJobInfo.SeekerID and AppliedJobInfo.AppliedJobID = " + id;

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<AppliedJob> appliedCandidateslist = new List<AppliedJob>();

            while (reader.Read())
            {
                int appliedJobID = Convert.ToInt32(reader["AppliedJobID"]);
                int seekerID = Convert.ToInt32(reader["SeekerID"]);
                string seekerName = reader["Name"].ToString();
                string seekerEmail = reader["Email"].ToString();
                string seekerAddress = reader["Address"].ToString();
                string gender = reader["Type"].ToString();
                string coverLetter = reader["CoverLetter"].ToString();
                DateTime appliedTime = Convert.ToDateTime(reader["AppliedTime"]);


                AppliedJob appliedJob = new AppliedJob(appliedJobID, seekerID, seekerName, seekerEmail, seekerAddress, gender, coverLetter, appliedTime);

                appliedCandidateslist.Add(appliedJob);
            }
            return appliedCandidateslist;
        }



    }
}
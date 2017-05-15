using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Models
{
    public class AppliedJob
    {
        public int AppliedJobID { get; set; }
        public int SeekerID { get; set; }
        public int JobID { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Cover Letter")]
        public string CoverLetter { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Applied Time")]
        public DateTime AppliedTime { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        public string JobNature { get; set; }

        public string EducationalRequirements { get; set; }

        public string ExperienceRequirements { get; set; }

        public string AdditionalRequirements { get; set; }

        public int NoOfVacancies { get; set; }

        public string SalaryRange { get; set; }

        public string OtherBenefit { get; set; }

        public DateTime ApplicationDeadline { get; set; }

        public DateTime PublishTime { get; set; }

        public string CompanyName { get; set; }

        public string CompanyEmail { get; set; }

        public string SeekerName { get; set; }
        public string SeekerEmail { get; set; }

        public string SeekerAddress { get; set; }

        [DisplayName("Gender")]
        public string SeekerGender { get; set; }


        public AppliedJob(int appliedJobID,  int jobID, string seekerName, string seekerEmail, string coverLetter, DateTime appliedTime, string jobTitle, string jobDescription, string jobNature, string educationalRequirements, string experienceRequirements, string additionalRequirements, int noOfVacancies, string salaryRange, string otherBenefit, DateTime applicationDeadline, DateTime publishTime, string companyName, string companyEmail)
        {
            this.AppliedJobID = appliedJobID;
            this.JobID = jobID;
            this.SeekerName = seekerName;
            this.SeekerEmail = seekerEmail;
            this.CoverLetter = coverLetter;
            this.AppliedTime = appliedTime;
            this.JobTitle = jobTitle;
            this.JobDescription = jobDescription;
            this.JobNature = jobNature;
            this.EducationalRequirements = educationalRequirements;
            this.ExperienceRequirements = experienceRequirements;
            this.AdditionalRequirements = additionalRequirements;
            this.NoOfVacancies = noOfVacancies;
            this.SalaryRange = salaryRange;
            this.OtherBenefit = otherBenefit;
            this.ApplicationDeadline = applicationDeadline;
            this.PublishTime = publishTime;
            this.CompanyName = companyName;
            this.CompanyEmail = companyEmail;
        }

        public AppliedJob()
        {
            
        }

        public AppliedJob(string coverLetter, DateTime appliedTime)
        {
            this.CoverLetter = coverLetter;
            this.AppliedTime = appliedTime;
        }

        public AppliedJob(int appliedJobID, int seekerID, string seekerName, string seekerEmail, string seekerAddress, string seekerGender, string coverLetter, DateTime appliedTime)
        {
            this.AppliedJobID = appliedJobID;
            this.SeekerID = seekerID;
            this.SeekerName = seekerName;
            this.SeekerEmail = seekerEmail;
            this.SeekerAddress = seekerAddress;
            this.SeekerGender = seekerGender;
            this.CoverLetter = coverLetter;
            this.AppliedTime = appliedTime;
        }
    }
}
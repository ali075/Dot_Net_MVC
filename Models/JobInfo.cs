using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobInfo
    {
        public int JobID { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Job Description")]
        [DataType(DataType.MultilineText)]
        public string JobDescription { get; set; }

        [Required]
        [DisplayName("Job Nature")]
        public string JobNature { get; set; }

        [Required]
        [DisplayName("Educational Requirements")]
        [DataType(DataType.MultilineText)]
        public string EducationalRequirements { get; set; }

        [Required]
        [DisplayName("Experience Requirements")]
        [DataType(DataType.MultilineText)]
        public string ExperienceRequirements { get; set; }

        [Required]
        [DisplayName("Additional Requirements")]
        [DataType(DataType.MultilineText)]
        public string AdditionalRequirements { get; set; }

        [Required]
        [DisplayName("Number Of Vacancies")]
        public int NoOfVacancies { get; set; }

        [Required]
        [DisplayName("Salary Range")]
        public string SalaryRange { get; set; }

        [Required]
        [DisplayName("Other Benefit")]
        [DataType(DataType.MultilineText)]
        public string OtherBenefit { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Application Deadline")]
        public DateTime ApplicationDeadline { get; set; }

        public int EmployerID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Publish Time")]
        public DateTime PublishTime { get; set; }

        public string CompanyName { get; set; }


        public JobInfo()
        {
            
        }

        public JobInfo(string jobTitle, string jobDescription, string jobNature, string educationalRequirements, string experienceRequirements, string additionalRequirements, int noOfVacancies, string salaryRange, string otherBenefit, DateTime applicationDeadline , int employerID, DateTime publishTime)
        {
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
            this.EmployerID = employerID;
            this.PublishTime = publishTime;
        }

        public JobInfo( string jobTitle, string jobDescription, string jobNature, string educationalRequirements, string experienceRequirements, string additionalRequirements, int noOfVacancies, string salaryRange, string otherBenefit, DateTime applicationDeadline, DateTime publishTime, string companyName)
        {
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
        }

        public JobInfo(int id, string jobTitle, string jobDescription, string jobNature, string educationalRequirements, string experienceRequirements, string additionalRequirements, int noOfVacancies, string salaryRange, string otherBenefit, DateTime applicationDeadline, DateTime publishTime, string companyName)
        {
            this.JobID = id;
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
        }
    }
}
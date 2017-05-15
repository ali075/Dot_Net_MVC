using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Employer
    {

        public string DisplayName { get; set; }

        public int EmployerID { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [DisplayName("Contact Person Name")]
        public string ContactPersonName { get; set; }

        [Required]
        [DisplayName("Contact Person Designation")]
        public string ContactPersonDesignation { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [DisplayName("Contact Person Mobile Number")]
        public string ContactPersonMobileNo { get; set; }

        [Required]
        [DisplayName("Contact Person Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string ContactPersonEmail { get; set; }

        [Required]
        [DisplayName("Industry Type")]
        public string IndustryType { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Company Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Company Website")]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Employer()
        {
            
        }

        public Employer(int employerId, string companyName, string contactPersonName, string designation, string mobileNo, string email, string industryType, string address, string website, string password)
        {
            this.EmployerID = employerId;
            this.CompanyName = companyName;
            this.ContactPersonName = contactPersonName;
            this.ContactPersonDesignation = designation;
            this.ContactPersonMobileNo = mobileNo;
            this.ContactPersonEmail = email;
            this.IndustryType = industryType;
            this.Address = address;
            this.Website = website;
            this.Password = password;
        }

        
    }
}
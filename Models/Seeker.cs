using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Seeker
    {
        public string DisplayName { get; set; }

        public int SeekerID { get; set; } 
        public string Name { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int Gender { get; set; }

        [Required(ErrorMessage = "Enter Your Contact Number")]
        [RegularExpression(@"^\(?([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Enter valid Digits. ex. (017XXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Please Enter Valid Phone Number")]
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [DisplayName("Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Home Address")]
        [DisplayName("Home Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //[Required]
        //public string Resume { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [DisplayName("Select Your Resume")]
        public HttpPostedFileBase Resume { get; set; }

        public Seeker(string firstName, string lastName, int gender, string mobile, string email, string address, string password)
        {
            this.Name = firstName + " " + lastName;
            this.Gender = gender;
            this.MobileNo = mobile;
            this.Email = email;
            this.Address = address;
            this.Password = password;
        }

        public Seeker(HttpPostedFileBase resume)
        {
            this.Resume = resume;
        }

        public Seeker()
        {
            
        }

        
    }
}
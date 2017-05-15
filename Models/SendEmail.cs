using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class SendEmail
    {

        [Required]
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        [Required]
        public string UserID { get; set; }
        [Required]
        public string Password { get; set; }


        public SendEmail()
        {
            
        }

        public SendEmail(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }

        public SendEmail(string userID, string password)
        {
            this.UserID = userID;
            this.Password = password;
        }
    }
}
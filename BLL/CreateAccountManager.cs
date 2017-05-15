using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class CreateAccountManager
    {

        CreateAccountGetway createAccountGetway = new CreateAccountGetway();

        public List<Gender> GetGenderInfo()
        {
            List<Gender> genderList = createAccountGetway.GetGenderInfo();
            return genderList;
        }

        public string InsertSeekerInfo(Seeker seeker)
        {
            string message = "Insertion Failed";

            bool isMobileNo = createAccountGetway.IsUniqueMobileNo(seeker);
            bool isEmail = createAccountGetway.IsUniqueSeekerEmail(seeker);
           
            if (isMobileNo)
            {
                message = "This mobile number is already registered ";
                return message;
            }
            else if (isEmail)
            {
                message = "This email address is already resistered";
                return message;
            }
            else
            {
                int isInserted = createAccountGetway.InsertSeekerInfo(seeker);
                if (isInserted > 0)
                {
                    message = "Create your account Successfully";
                }
                return message;
            }

        }

        public string InsertEmployerInfo(Employer employer)
        {
            string message = "Insertion Failed";

            bool isEmail = createAccountGetway.IsUniqueCompanyEmail(employer);

            if (isEmail)
            {
                message = "This email address is already resistered";
                return message;
            }
            else
            {
                int isInserted = createAccountGetway.InsertEmployerInfo(employer);
                if (isInserted > 0)
                {
                    message = "Create your account Successfully";
                }
                return message;
            }
        }

    }
}
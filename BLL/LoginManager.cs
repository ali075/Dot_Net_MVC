using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class LoginManager
    {
        LoginGetway loginGetway = new LoginGetway();

        public string GetSeekerName(LoginAccount login)
        {
            bool isExist = loginGetway.IsSeekerEmailPasswordExist( login);

            string name = "";
            if (isExist)
            {
               name = loginGetway.SeekerGetName( login);
            }
            return name;
        }

        public string GetEmployerCompanyName( LoginAccount login)
        {
            bool isExist = loginGetway.IsEmployerEmailPasswordExist( login);

            string name = "";
            if (isExist)
            {
                name = loginGetway.EmployerGetName(login);
            }
            return name;
        }

        public int GetEmployerCompanyID(LoginAccount login)
        {
            bool isExist = loginGetway.IsEmployerEmailPasswordExist( login);

            int id = 0;

            if (isExist)
            {
                id = loginGetway.GetEmployerID( login);
            }
            return id;
        }

        public int GetSeekerID(LoginAccount login)
        {
            bool isExist = loginGetway.IsSeekerEmailPasswordExist(login);

            int id = 0;

            if (isExist)
            {
                id = loginGetway.GetSeekerID(login);
            }
            return id;
        }
        
        
        


        

    }
}
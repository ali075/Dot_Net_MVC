using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class EmployerManager
    {
        EmployerGetway employerGetway = new EmployerGetway();
        public Employer GetEmployerInfo(Employer employer)
        {
            return employerGetway.GetEmployerInfo(employer);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.BLL;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class LoginController : Controller
    {
        LoginManager loginManager = new LoginManager();
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginAccount()
        {
            var seeker = Session["user"] as Seeker;
            var employer = Session["user"] as Employer;

            if (seeker != null || employer != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult LoginAccount(Employer employer, Seeker seeker, LoginAccount login)
        {
            string seekerName = loginManager.GetSeekerName(login);
            int seekerId = loginManager.GetSeekerID(login);

            string employerName = loginManager.GetEmployerCompanyName(login);
            int employerId = loginManager.GetEmployerCompanyID(login);

            if (!seekerName.Equals(""))
            {
                Session["user"] = new Seeker() { DisplayName = seeker.Name, Name = seekerName, SeekerID = seekerId };
                return RedirectToAction("Index", "Home");
            }
            else if (!employerName.Equals(""))
            {
                Session["user"] = new Employer() { DisplayName = employer.CompanyName, CompanyName = employerName, EmployerID = employerId };
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string message = "Email or Password is Incorrect";
                ViewBag.message = message;
            }

            return View();
        }
	}
}
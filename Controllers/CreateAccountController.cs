using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.BLL;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class CreateAccountController : Controller
    {

        CreateAccountManager createAccountManager = new CreateAccountManager();

        public ActionResult SeekerAccount()
        {
            ViewBag.genderList = GetGenderInfo();
            ViewBag.message = " ";
            return View();
        }

        [HttpPost]
        public ActionResult SeekerAccount(Seeker seeker)
        {
            ViewBag.genderList = GetGenderInfo();
            string message = createAccountManager.InsertSeekerInfo(seeker);
            ViewBag.message = message;
            return View();
        }

        public ActionResult EmployerAccount()
        {
            ViewBag.message = " ";
            return View();
        }

        [HttpPost]
        public ActionResult EmployerAccount(Employer employer)
        {
            string message = createAccountManager.InsertEmployerInfo(employer);
            ViewBag.message = message;
            return View();
        }

        private List<SelectListItem> GetGenderInfo()
        {
            List<Gender> genderList = createAccountManager.GetGenderInfo();
            List<SelectListItem> genders = new List<SelectListItem>();
            foreach (var item in genderList)
            {
                genders.Add(new SelectListItem() { Value = item.ID.ToString(), Text = item.Type });
            }
            return genders;
        }
	}
}
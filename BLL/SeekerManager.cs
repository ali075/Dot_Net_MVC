using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class SeekerManager
    {
        SeekerGetway seekerGetway = new SeekerGetway();

        public string UpdateResume(Seeker seeker, int id)
        {
            string message = " Resume  Upload Failed";

            int isInserted = seekerGetway.UpdateResume(seeker, id);
            if (isInserted > 0)
            {
                message = "Resume Uploaded Successfully";
            }
            return message;
        }

    }
}
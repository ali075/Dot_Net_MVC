using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class Gender
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public Gender(int ID, string type)
        {
            this.ID = ID;
            this.Type = type;
        }
    }
}
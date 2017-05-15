using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.DAL
{
    public class Connection
    {

        public string GetConnection()
        {
            string connectionString = @"Server=ALI; Database = JobPortal; Integrated Security=true";

            return connectionString;

        }
    }
}
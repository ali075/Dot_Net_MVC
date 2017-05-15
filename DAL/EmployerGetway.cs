using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class EmployerGetway
    {

        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public Employer GetEmployerInfo(Employer employer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select EmployerID from EmployersInfo where ContactPersonEmail = (@contactPersonEmail)";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = employer.ContactPersonEmail;

            command.CommandText = query;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            Employer emp = new Employer();

            if (reader.Read())
            {
                int id = Convert.ToInt32(reader["EmployerID"]);
                string companyName = reader["CompanyName"].ToString();
                string contactPersonName = reader["ContactPersonName"].ToString();
                string designation = reader["ContactPersonDesignation"].ToString();
                string mobileNo = reader["ContactPersonMobileNo"].ToString();
                string email = reader["ContactPersonEmail"].ToString();
                string industryType = reader["IndustryType"].ToString();
                string address = reader["CompanyAddress"].ToString();
                string website = reader["CompanyWebsite"].ToString();
                string password = reader["Password"].ToString();

               emp = new Employer(id, companyName, contactPersonName, designation, mobileNo, email, industryType, address, website, password);
            }
            return emp;

        }
    }
}
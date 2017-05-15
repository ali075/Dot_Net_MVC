using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class CreateAccountGetway
    {
        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public List<Gender> GetGenderInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Gender";
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Gender> genderList = new List<Gender>();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ID"]);
                string type = reader["Type"].ToString();

                Gender gender = new Gender(id, type);
                genderList.Add(gender);
            }
            return genderList;
        }


        public int InsertSeekerInfo(Seeker seeker)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO JobSeekersInfo (Name, GenderID, MobileNo, Email, Address, Password) VALUES (@name, @genderID, @mobileNo, @email, @address, @password)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = seeker.FirstName + " " + seeker.LastName;

            command.Parameters.Add("genderID", SqlDbType.Int);
            command.Parameters["genderID"].Value = seeker.Gender;

            command.Parameters.Add("mobileNo", SqlDbType.VarChar);
            command.Parameters["mobileNo"].Value = seeker.MobileNo;

            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = seeker.Email;

            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = seeker.Address;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = seeker.Password;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }


        public bool IsUniqueMobileNo(Seeker seeker)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from JobSeekersInfo where MobileNo =(@mobileNo)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("mobileNo", SqlDbType.VarChar);
            command.Parameters["mobileNo"].Value = seeker.MobileNo;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUniqueSeekerEmail(Seeker seeker)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from JobSeekersInfo where Email =(@email)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = seeker.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int InsertEmployerInfo(Employer employer)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO EmployersInfo (CompanyName, ContactPersonName, ContactPersonDesignation, ContactPersonMobileNo, ContactPersonEmail, IndustryType, CompanyAddress, CompanyWebsite, Password) VALUES (@companyName, @contactPersonName, @contactPersonDesignation, @contactPersonMobileNo, @contactPersonEmail, @industryType, @companyAddress, @companyWebsite, @password)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("companyName", SqlDbType.VarChar);
            command.Parameters["companyName"].Value = employer.CompanyName;

            command.Parameters.Add("contactPersonName", SqlDbType.VarChar);
            command.Parameters["contactPersonName"].Value = employer.ContactPersonName;

            command.Parameters.Add("contactPersonDesignation", SqlDbType.VarChar);
            command.Parameters["contactPersonDesignation"].Value = employer.ContactPersonDesignation;

            command.Parameters.Add("contactPersonMobileNo", SqlDbType.VarChar);
            command.Parameters["contactPersonMobileNo"].Value = employer.ContactPersonMobileNo;

            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = employer.ContactPersonEmail;

            command.Parameters.Add("industryType", SqlDbType.VarChar);
            command.Parameters["industryType"].Value = employer.IndustryType;

            command.Parameters.Add("companyAddress", SqlDbType.VarChar);
            command.Parameters["companyAddress"].Value = employer.Address;

            command.Parameters.Add("companyWebsite", SqlDbType.VarChar);
            command.Parameters["companyWebsite"].Value = employer.Website;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = employer.Password;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public bool IsUniqueCompanyEmail(Employer employer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from EmployersInfo where ContactPersonEmail =(@contactPersonEmail)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = employer.ContactPersonEmail;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
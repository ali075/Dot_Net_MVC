using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class LoginGetway
    {
        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public string SeekerGetName(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Name from JobSeekersInfo where Email = @email";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = login.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            string name = "";
            if (reader.Read())
            {
                name = reader["Name"].ToString();
            }
            return name;
        }

        public bool IsSeekerEmailPasswordExist(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from JobSeekersInfo where Email =(@email) and Password =(@password)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = login.Email;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = login.Password;

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


        public string EmployerGetName(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select CompanyName from EmployersInfo where ContactPersonEmail = @contactPersonEmail";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = login.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            string name = "";
            if (reader.Read())
            {
                name = reader["CompanyName"].ToString();
            }
            return name;
        }

        public bool IsEmployerEmailPasswordExist(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from EmployersInfo where ContactPersonEmail =(@contactPersonEmail) and Password =(@password)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            

            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = login.Email;

            command.Parameters.Add("password", SqlDbType.VarChar);
            command.Parameters["password"].Value = login.Password;

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

        public int GetEmployerID(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select EmployerID from EmployersInfo where ContactPersonEmail = @contactPersonEmail";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("contactPersonEmail", SqlDbType.VarChar);
            command.Parameters["contactPersonEmail"].Value = login.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader["EmployerID"]);
            }
            return id;
        }

        public int GetSeekerID(LoginAccount login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select SeekerID from JobSeekersInfo where Email = @email";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = login.Email;

            command.CommandText = query;
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader["SeekerID"]);
            }
            return id;
        }

    }
}
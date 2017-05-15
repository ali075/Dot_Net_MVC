using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JobPortal.Models;

namespace JobPortal.DAL
{
    public class SeekerGetway
    {

        static Connection con = new Connection();
        private string connectionString = con.GetConnection();

        public int UpdateResume(Seeker seeker, int id)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE JobSeekersInfo SET Resume = (@resume), WHERE SeekerID = (@seekerID)";
            //string query = "insert into JobSeekersInfo (Resume) values (@resume) where SeekerID = (@seekerID)";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("resume", SqlDbType.VarBinary);
            command.Parameters["resume"].Value = seeker.Resume;
            //command.Parameters["resume"].Value = Convert.ToByte(seeker.Resume);



            command.Parameters.Add("SeekerID", SqlDbType.Int);
            command.Parameters["SeekerID"].Value = id;

            command.CommandText = query;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;

        }




    }
}
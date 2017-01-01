using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ASPJ.Admin
{
    public class KeyManager
    {
        public static void changeKey(string userID,string pubKey)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("changeKey", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", userID));
                command.Parameters.Add(new SqlParameter("@pubKey", pubKey));

                command.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.ToString());
            }
        }
        public static string retrievePublicKey(string userID)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            string pubKey = null;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("retrieveKey", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", userID));

                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    pubKey = myReader["pubKey"].ToString();
                }
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.ToString());
            }
            return pubKey;
        }
        public static void setLastLogin(string userID)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("setLastLogin", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", userID));

                command.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.ToString());
            }
        }
        public static string retrieveLastLogin(string userID)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            string lastLogin = null;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("retrieveKey", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", userID));

                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    lastLogin = myReader["lastLogin2"].ToString();
                }
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.ToString());
            }
            return lastLogin;
        }
    }
}
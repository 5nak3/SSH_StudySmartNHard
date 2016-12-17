using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;

namespace ASPJ
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String user = "ITstudent1";
        protected void Page_Load(object sender, EventArgs e)
        {
            friendList.Items.Clear();
            initFriendList();
            NotificationComponent NC = new NotificationComponent();
            NC.RegisterNotification(DateTime.Now);
        }
        protected void initFriendList()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {

                myConnection.Open();
                Debug.WriteLine("Test");
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM users WHERE userID=@userID", myConnection);
                command.Parameters.Add(new SqlParameter("userID", user));
                Debug.WriteLine("Test2");
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    testLabel.Text = myReader["userID"].ToString();
                }
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }

            List<String> friends = new List<String>();
            try
            {

                myConnection.Open();
                Debug.WriteLine("Test");
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM friendList WHERE requestStatus='accept' AND userID=@userID", myConnection);
                command.Parameters.Add(new SqlParameter("userID", user));
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    friends.Add(myReader["friendID"].ToString());
                }

                SqlDataReader myReader2 = null;
                SqlCommand command2 = new SqlCommand("SELECT * FROM friendList WHERE requestStatus='accept' AND friendID=@userID", myConnection);
                command2.Parameters.Add(new SqlParameter("userID", user));
                myReader2 = command2.ExecuteReader();
                while (myReader2.Read())
                {
                    friends.Add(myReader2["userID"].ToString());
                }
                myConnection.Close();
                foreach (String friend in friends)
                {
                    friendList.Items.Add(new ListItem(friend, friend));
                }

            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
        }
        protected void friendList1_Click(object sender,
        BulletedListEventArgs e)
        {
            ListItem li = friendList.Items[e.Index];
            Utils.show(this, li.Value);
        }
        protected void searchFriend()
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {

                myConnection.Open();
                Debug.WriteLine("Test");
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM users WHERE userID=@userID", myConnection);
                command.Parameters.Add(new SqlParameter("userID", user));
                Debug.WriteLine("Test2");
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    testLabel.Text = myReader["userID"].ToString();
                }
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
        }
        protected void addFriend_clicked(Object sender, EventArgs e)
        {
            string userID = user;
            string friendID = searchFriendBox.Text;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("add_friend", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", userID));
                command.Parameters.Add(new SqlParameter("@friendID", friendID));


                SqlParameter parmOut = new SqlParameter("@result", SqlDbType.Int);
                parmOut.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(parmOut);
                command.ExecuteNonQuery();
                int result = (int)parmOut.Value;
                Debug.WriteLine(result);
                if (result == 0)
                {
                    add_result.Text = "successful";
                }
                else
                {
                    add_result.Text = "Friend Record already Exist";
                }
                add_result.Style.Add("display", "inline");
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
        }

        
        //        
        
    }
}
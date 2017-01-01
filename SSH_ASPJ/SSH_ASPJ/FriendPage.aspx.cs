using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ASPJ
{

    public partial class FriendPage : System.Web.UI.Page
    {
        List<Button> bList = new List<Button>();
        List<string> requests = new List<string>();
        string user = "ITstudent1";
        protected void Page_Load(object sender, EventArgs e)
        {
            getFriendRequest();
        }
        public void getFriendRequest()
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                Debug.WriteLine("I am outside");
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand command = new SqlCommand("SELECT * FROM friendList WHERE requestStatus='request' AND friendID=@userID", myConnection);
                command.Parameters.Add(new SqlParameter("userID", user));
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    requests.Add(myReader["userID"].ToString());
                    Debug.WriteLine("This is running");
                    Panel p = new Panel();
                    Label l = new Label();
                    l.Text = myReader["userID"].ToString();

                    p.Controls.Add(l);
                    Button b = new Button();
                    b.Click += acceptFriend;
                    b.Text = "Accept Friend Request";

                    bList.Add(b);

                    p.Controls.Add(l);
                    p.Controls.Add(b);

                    RequestPanel.Controls.Add(p);
                }


            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
        }
        public void acceptFriend(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            string requester = requests[bList.IndexOf(clicked)];

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                myConnection.Open();
 
                SqlCommand command = new SqlCommand("acceptFriend", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("userID", requester));
                command.Parameters.Add(new SqlParameter("friendID", user));

                SqlParameter parmOut = new SqlParameter("@result", SqlDbType.Int);
                parmOut.Direction = System.Data.ParameterDirection.ReturnValue;
                command.Parameters.Add(parmOut);
                command.ExecuteNonQuery();
                int result = (int)parmOut.Value;
                Debug.WriteLine(result);
                if (result == 0)
                {
                    clicked.Text = "Friend Added";
                    clicked.Enabled = false;
                }
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }

        }

    }
}
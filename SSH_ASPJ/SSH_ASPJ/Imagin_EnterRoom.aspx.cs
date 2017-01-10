using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Imagin2
{
    public partial class Imagin_EnterRoom : System.Web.UI.Page
    {
        protected string roomCode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int count;

            //Get value from TextBox1
            roomCode = TextBox1.Text;

            //Set session keys for roomCode
            Session["roomCode"] = roomCode;

            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT COUNT(*) from Imagin1Table WHERE roomCode = @roomCode;";
                cmd.Parameters.AddWithValue("@roomCode", roomCode);

                cmd.Connection = con;
                con.Open();

                count = ((int)cmd.ExecuteScalar());

                cmd.ExecuteNonQuery();

                if (count <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No such room found!');", true);
                }
                else
                {
                    cmd.CommandText = "UPDATE Imagin1Table SET roomCode = '" + roomCode + "' WHERE userId = @userID;";
                    //cmd.Parameters.AddWithValue("@roomCode", Session["roomCode"]);
                    cmd.Parameters.AddWithValue("@userID", Session["userID"]);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Imagin_Room.aspx");
                }

                con.Close();

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Imagin2
{
    public partial class Imagin_Home : System.Web.UI.Page
    {
        String roomCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Buffer storage.
                byte[] data = new byte[4];

                rng.GetBytes(data);

                int value = BitConverter.ToInt32(data, 0);
                roomCode = value.ToString();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session["roomCode"] = roomCode;

            String constr = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            String command = "update Imagin1Table set roomCode = @roomCode where userID = @userID";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@roomCode", Session["roomCode"]);
                    cmd.Parameters.AddWithValue("@userID", Session["userID"]);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }

            Response.Redirect("Imagin_Room.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Imagin_EnterRoom.aspx");
        }
    }
}
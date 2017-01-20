using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSH_ASPJ.Study_Spot
{
    public partial class Baseline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
            protected void Submit_Click(object sender, EventArgs e)
            {
            string query = "INSERT INTO Pages VALUES (@PageName, @Title, @Content)";
            string conString = ConfigurationManager.ConnectionStrings["yusiangstring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PageName", "Study Spot Review".Replace(" ", "-"));
                    cmd.Parameters.AddWithValue("@Title", "Title");
                    cmd.Parameters.AddWithValue("@Content", "Content");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("~/Default.aspx");
                }
            }
            }
    }
    }

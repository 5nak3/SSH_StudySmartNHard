using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSH_ASPJ.Study_Spot
{
    public partial class DynamicMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.PopulatePage();
            }
        }



            private void PopulatePage()
            {
                //string pageName = this.Page.RouteData.Values["PageName"].ToString();
                string query = "SELECT PageName FROM Pages";
                string conString = ConfigurationManager.ConnectionStrings["yusiangstring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            //cmd.Parameters.AddWithValue("@PageName", pageName);
                            //cmd.Connection = con;
                            //sda.SelectCommand = cmd;
                            //using (DataTable dt = new DataTable())
                            //{
                                //sda.Fill(dt);
                                //lblTitle.Text = dt.Rows[0]["Title"].ToString();
                                //lblContent.Text = dt.Rows[0]["Content"].ToString();
                            //}   
                        }
                    }
                }
            }   
        }
    }

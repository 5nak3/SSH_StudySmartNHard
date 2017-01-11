using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// For Repeater
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SSH_ASPJ.PwdMgr
{
    public partial class Pwdmgr_App : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            string constr = ConfigurationManager.ConnectionStrings["SSH_ASPJ"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                // Making use of ADO.net to obtain data from multiple tables
                // Batch Query
                string selectStmt = "SELECT * FROM pwdManager WHERE userID = @userID;" +
                                    "SELECT * FROM pwdAnalysis WHERE pwdID = @pwdID";
                using (SqlCommand cmd = new SqlCommand(selectStmt, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptPassword.DataSource = dt;
                        rptPassword.DataBind();
                    }
                }
            }
        }
    }
}
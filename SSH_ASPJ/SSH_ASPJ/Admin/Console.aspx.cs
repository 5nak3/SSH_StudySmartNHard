using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ.Admin
{
    public partial class Console : System.Web.UI.Page
    {
        string userID = "Admin";
        protected void Page_Load(object sender, EventArgs e)
        {
            string lastLoginTime=KeyManager.retrieveLastLogin(userID);
            Debug.WriteLine(lastLoginTime);
            if (lastLoginTime != "")
            {
                lastLogin.Text = "Last Login at "+lastLoginTime;
            }
            else
            {
                lastLogin.Text = "this is your first time login in";
            }
        }
    }
}
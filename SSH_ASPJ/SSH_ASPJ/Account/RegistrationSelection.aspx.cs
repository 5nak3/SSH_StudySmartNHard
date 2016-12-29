using System;
using System.Web.UI;

namespace SSH_ASPJ.Account
{
    public partial class RegistrationSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void menteeButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MenteeRegister.aspx");
        }

        protected void mentorButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MentorRegistration.aspx");
        }
    }
}
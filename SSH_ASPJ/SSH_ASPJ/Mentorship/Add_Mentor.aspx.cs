using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class Add_Mentor : System.Web.UI.Page
    {
        string mentor = "ITmentor1";
        string userID = "ITstudent1";
        protected void Page_Load(object sender, EventArgs e)
        {
            mentor = Request.QueryString["mentor"];
            MentorName.Text = mentor;
            
        }
        public void sendRequest_Clicked(Object sender, EventArgs e)
        {
            string invitationText = InvitationText.Text;
            Relation r = new Relation(userID,mentor,invitationText);    
            int result = r.sendRequest();

            if (result == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have successfully sent a request to " + mentor+"'); window.location='" +
                    "/Mentorship.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ou already send a request or he/she is already mentor'); window.location='" +
                    "/Mentorship.aspx';", true);
            }


        }
    }
}
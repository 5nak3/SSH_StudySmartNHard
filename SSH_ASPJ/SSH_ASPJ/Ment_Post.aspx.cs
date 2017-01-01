using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class Ment_Post : System.Web.UI.Page
    {
        string userID = "ITmentor1";
        int userMode;
        protected void Page_Load(object sender, EventArgs e)
        {
            userMode = Mentorship.checkUserMode(userID);
            if (userMode==1)
            {
                select.Text = "Select your Mentor";
                List<Relation> rList = Relation.getMentor(userID);
                foreach(Relation r in rList)
                {
                    MentorList.Items.Add(new ListItem(r.mentorID));
                }
                
            }
            else if(userMode == 2)
            {
                select.Text = "Select your Mentee";
                List<Relation> rList = Relation.getMentee(userID);
                foreach (Relation r in rList)
                {
                    MentorList.Items.Add(new ListItem(r.menteeID));
                }
            }
            post.Click += postRelation;
            Logger.accessLogging(DateTime.Now + "," + userID + ",Ment_Post.aspx");
        }

        public void postRelation(object sender,EventArgs e)
        {
            Relation r=null;
            if (userMode == 1)
            {
                r = Relation.getRelationByID(MentorList.SelectedItem.Value,userID);
            }
            else if(userMode == 2)
            {
                r = Relation.getRelationByID(userID, MentorList.SelectedItem.Value);
            }
            RelationPost p = new RelationPost(userID,r,topic.Text);
            int result = p.post(content.Text);

            if (result == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully posted topic'); window.location='" +
                    "/Mentorship.aspx';", true);     
            }
        }
    }
}
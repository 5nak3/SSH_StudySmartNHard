using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ
{
    public partial class Post_Content : System.Web.UI.Page
    {
        string userID = "ITstudent1";
        int postID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["postID"] != null)
            {
                postID = Convert.ToInt32(Request.QueryString["postID"]);

                reply.Click += replyTopic;
                if (checkAccess() == 1)
                {
                    RelationPost rp = RelationPost.getRelationPostByID(postID);
                    List<RelationPostContent> cList = RelationPostContent.getRelationContent(postID);
                    title.Text = "Title: " + rp.title;

                    foreach (RelationPostContent c in cList)
                    {
                        Debug.WriteLine("This is running");
                        Panel post = new Panel();
                        post.CssClass = "post";
                        
                        Panel userDetails = new Panel();
                        userDetails.CssClass = "user-detail";
                        
                        Label user = new Label();
                        user.Text = c.postedBy;
                        userDetails.Controls.Add(user);

                        post.Controls.Add(userDetails);

                        Panel contentText = new Panel();
                        content.CssClass = "contentText";

                        TextBox b = new TextBox();
                        b.CssClass = "contentBox";
                        b.Wrap = true;
                        b.Rows = 5;                        
                        b.ReadOnly = true;
                        b.TextMode = TextBoxMode.MultiLine;
                        
                        b.Text = c.postBody;
                        contentText.Controls.Add(b);

                        post.Controls.Add(contentText);

                        Panel padding = new Panel();
                        padding.CssClass = "padding";
                        Label l = new Label();
                        l.Text = c.threadTime.ToString();
                        padding.Controls.Add(l);

                        content.Controls.Add(post);
                        content.Controls.Add(padding);
                    }
                }
            }
            Logger.accessLogging(DateTime.Now + "," + userID + ",Ment_Post.aspx"); Logger.accessLogging(DateTime.Now + "," + userID + ",Post_Content.aspx");
        }
        public int checkAccess()
        {
            return 1;
        }

        public void replyTopic(object sender, EventArgs e)
        {
            string postBody = replyContent.Text;
            string postedBy = userID;
            RelationPostContent p = new RelationPostContent(postID, postBody, postedBy);
            int success = p.replyContent();
            Debug.WriteLine(success);
            if (success != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully reply topic'); window.location='" +
                    "/Mentorship/Mentorship.aspx';", true);
            }
        }
    }
}
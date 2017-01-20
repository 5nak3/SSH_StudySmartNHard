using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace ASPJ
{
    public partial class Mentorship : System.Web.UI.Page
    {
        string userID = "ITstudent1";
        TextBox mentor = new TextBox();
        List<Button> bList = new List<Button>();
        List<string> menteeList = new List<string>();
        List<RelationPost> rList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["userID"] != null)
            {
                userID = Request.QueryString["userID"];
            }
            if (checkUserMode(userID) == 1)
            {
                Label l = new Label(); ;
                l.Text = "Your Mentors";
                BulletedList lList = new BulletedList();
                getMentor(lList);


                mentHeader.Controls.Add(l);
                mentPanel.Controls.Add(lList);

                Label l1 = new Label();
                l1.Text = "Find Mentor";
                Button b = new Button();
                b.Text = "Send Request";
                b.Click += request_Clicked;
                findMent.Controls.Add(l1);
                findMent.Controls.Add(mentor);
                findMent.Controls.Add(b);


            }
            else if (checkUserMode(userID) == 2)
            {
                Label l = new Label(); ;
                l.Text = "Your Mentees";

                BulletedList lList = new BulletedList();
                getMentee(lList);

                mentHeader.Controls.Add(l);
                mentPanel.Controls.Add(lList);

                getMenteeRequest();

            }
            Button c = new Button();
            c.Text = "Start A Topic";
            c.Click += startTopic;
            mentPanel.Controls.Add(c);
            getRelationPost();
            Logger.accessLogging(DateTime.Now + "," + userID + ",Mentorship.aspx");
        }
        public void startTopic(object sender, EventArgs e)
        {
            Response.Redirect("Ment_Post");
        }

        public void getMentor(BulletedList list)
        {
            List<Relation> rList = Relation.getMentor(userID);
            foreach(Relation r in rList)
            {
                list.Items.Add(new ListItem(r.mentorID));
            }

        }
        public void request_Clicked(object sender,EventArgs e)
        {
            if(checkUserMode(mentor.Text)==2)
                Response.Redirect("Add_Mentor.aspx?mentor=" + mentor.Text);
            
        }
        public void getMentee(BulletedList list)
        {
            List<Relation> rList = Relation.getMentee(userID);
            foreach (Relation r in rList)
            {
                list.Items.Add(new ListItem(r.menteeID));
            }
        }
        public static int checkUserMode(string user)
        {
            int userMode = 99;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["myConnection"].ConnectionString;
            try
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand("checkUserMode", myConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userID", user));


                SqlParameter parmOut = new SqlParameter("@userMode", SqlDbType.Int);
                parmOut.Direction = System.Data.ParameterDirection.ReturnValue;

                command.Parameters.Add(parmOut);
                command.ExecuteNonQuery();
                userMode = (int)parmOut.Value;
                
                
                myConnection.Close();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            Debug.WriteLine(userMode);
            return userMode;
        }

        public void getMenteeRequest()
        {
            List<Relation> rlist = Relation.getMenteeRequest(userID);
          
            foreach (Relation r in rlist)
            {
                Label l1 = new Label();
                l1.Text = r.menteeID;
                Button b = new Button();
                b.Text = "Accept";
                b.CommandArgument = r.menteeID;
                b.Command += accept_Request;

                Panel p = new Panel();
                p.Controls.Add(l1);
                p.Controls.Add(b);
                findMent.Controls.Add(p);
            }


        }
        public void accept_Request(object sender,CommandEventArgs e)
        {
            string menteeID = e.CommandArgument.ToString();
            Button clicked = sender as Button;
            Relation r = Relation.getRelationByID(userID, menteeID);
            
            int result = r.acceptRequest();
            Debug.WriteLine(result);
            if (result == 0)
            {
                clicked.Text = "Mentee Added";
                clicked.Enabled = false;
            }


        }
        public void getRelationPost()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerCell;
            string[] texts = { "Title ", "Posts", "Posted By" };
            for (int i = 0; i < texts.Length; i++)
            {
                headerCell = new TableHeaderCell();
                headerCell.Text = texts[i];
                headerCell.CssClass = "forumHeader";
                header.Cells.Add(headerCell);

                if (i == 0)
                {
                    headerCell.Style.Add("width", "600px");
                    headerCell.Style.Add("padding-left", "15px");
                }
            }
            forum.Rows.Add(header);

            rList = RelationPost.getRelationPost(userID);
            for (int i = 0; i < rList.Count; i++)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                HyperLink link = new HyperLink();
                link.NavigateUrl = "Post_Content.aspx?postID=" + rList[i].postID;
                link.Text = rList[i].title;
                cell.CssClass = "forumCell";
                cell.Controls.Add(link);
                cell.Style.Add("padding-left", "15px");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "" + RelationPostContent.retrieveNumOfPost(rList[i].postID);
                cell.CssClass = "forumCell";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = rList[i].postedBy;
                cell.CssClass = "forumCell";
                row.Cells.Add(cell);


                forum.Rows.Add(row);
            }
        }
    }
}
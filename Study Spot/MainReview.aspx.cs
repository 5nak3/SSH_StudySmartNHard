using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace SSH_ASPJ.Study_Spot
{
    public partial class MainReview : System.Web.UI.Page
    {
        private DataTable datatable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["yusiangstring"].ConnectionString;
            string query = "SELECT PostTitle FROM StudySpotPosts";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(datatable);
            conn.Close();

            if(datatable != null)
            {
                //Table1.HideColumn("Original");
                //string HTML = toHTML_Table(datatable);
                //TextBox1.Text += HTML;

                int counter = 0;

                
                

                for (int rowNum = 0; rowNum < datatable.Rows.Count; rowNum++)
                {
                    TableRow rw = new TableRow();

                    //for (int cellNum = 0; cellNum < 2; cellNum++)
                    //{
                    TableCell cel = new TableCell();
                    Button button = new Button();
                    Label label = new Label();
                    button.Text = "Click me to kill yourself.";
                    button.PostBackUrl = "http://localhost:56788/Admin/Console.aspx";
                    label.Text = datatable.Rows[rowNum][counter].ToString();
                    cel.Controls.Add(label);
                    cel.HorizontalAlign = HorizontalAlign.Center;
                    cel.Controls.Add(button);
                    rw.Cells.Add(cel);
                    

                    //}


                    Table1.Rows.Add(rw);
                    Table1.GridLines = GridLines.Both;
                    

                    Table1.Rows.Remove(Original);
                }
                
            }
            

            da.Dispose();
        }
        public static string toHTML_Table(DataTable dt)
        {
            if (dt.Rows.Count == 0) return ""; // enter code here

            StringBuilder builder = new StringBuilder();
            //builder.Append("<html>");
            //builder.Append("<head>");
            //builder.Append("<title>");
            //builder.Append("Page-");
            //builder.Append(Guid.NewGuid());
            //builder.Append("</title>");
            //builder.Append("</head>");
            //builder.Append("<body>");
            //builder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            //builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");
            builder.Append("<asp:TableRow style='border: 1px solid black' runat='server'>");
            foreach (DataColumn c in dt.Columns)
            {
                builder.Append("<asp:TableCell style='border: 1px solid black'><b>");
                builder.Append(c.ColumnName);
                builder.Append("</b></asp:TableCell>");
            }
            builder.Append("</asp:TableRow>");
            foreach (DataRow r in dt.Rows)
            {
                builder.Append("<asp:TableRow style='border: 1px solid black' align='left' valign='top' runat='server'>");
                foreach (DataColumn c in dt.Columns)
                {
                    builder.Append("<asp:TableCell style='border: 1px solid black' valign='top'>");
                    builder.Append(r[c.ColumnName]);
                    builder.Append("</asp:TableCell>");
                }
                builder.Append("</asp:TableRow>");
            }
            //builder.Append("</table>");
            //builder.Append("</body>");
            //builder.Append("</html>");

            return builder.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Imagin2
{
    public partial class Imagin_Room : System.Web.UI.Page
    {
        protected string roomCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (string)Session["roomCode"];
            roomCode = (string)Session["roomCode"];

            HiddenField1.Value = (string)Session["username"];
            HiddenField2.Value = (string)Session["roomCode"];

        }
    }
}
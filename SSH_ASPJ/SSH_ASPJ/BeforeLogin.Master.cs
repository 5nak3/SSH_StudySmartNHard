using System;
using System.Linq;

namespace SSH_ASPJ
{
    public partial class BeforeLogin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetCurrentPage();
        }

        private void SetCurrentPage()
        {
            var pageName = GetPageName();

            switch (pageName)
            {
                case "index.aspx":
                    home.Attributes["class"] = "active";
                    break;
            }
        }

        private string GetPageName()
        {
            return Request.Url.ToString().Split('/').Last();
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SSH_ASPJ.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SSH_ASPJ;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace SSH_ASPJ.Account
{
    public partial class Register : Page

    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
           // Debug.WriteLine(manager);
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new IdentityUser() { UserName = Username.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                // manager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("~/index.aspx");
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void PasswordSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PasswordSelection.SelectedValue == "1")
            {
                this.textPassword.Visible = true;
                this.imagePassword.Visible = false;
            }
            else if (this.PasswordSelection.SelectedValue == "2")
            {
                this.textPassword.Visible = false;
                this.imagePassword.Visible = true;
            }
        }
    }
}
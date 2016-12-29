using Microsoft.AspNet.Identity.Owin;
using SSH_ASPJ.Models;
using System;
using System.Web;
using System.Web.UI;

namespace SSH_ASPJ.Account
{
    public partial class MentorRegistration : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = mentorUsername.Text, Email = MentorEmail.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }

        protected void PasswordSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PasswordSelection.SelectedValue == "1")
                this.textPassword.Visible = true;
            else if (this.PasswordSelection.SelectedValue == "2")
                this.textPassword.Visible = false;
        }
    }
}
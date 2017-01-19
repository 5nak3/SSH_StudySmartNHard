using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SSH_ASPJ;
using SSH_ASPJ.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SSH_ASPJ.Account
{
    public partial class Register : Page

    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (textPassword.Visible == true)
            {
                //var userStore = new UserStore<IdentityUser>();
                //var manager = new UserManager<IdentityUser>(userStore);
                //// Debug.WriteLine(manager);
                ////var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                //var user = new IdentityUser() { UserName = Username.Text, Email = Email.Text };
                //IdentityResult result = manager.Create(user, Password.Text);

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text };

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
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            else if (imagePassword.Visible == true)
            {
                string fileExt = Path.GetExtension(imagePasswordControl.PostedFile.FileName);
                if (fileExt == ".jpg")
                {
                    // string filename = Path.GetFileName(imagePasswordControl.FileName);
                    byte[] imgbyte = imagePasswordControl.FileBytes;
                    //convert byte[] to Base64 string
                    string base64ImgString = Convert.ToBase64String(imgbyte);

                    var userStore = new UserStore<IdentityUser>();
                    var manager = new UserManager<IdentityUser>(userStore);
                    var user = new IdentityUser() { UserName = Username.Text, Email = Email.Text };
                    IdentityResult result = manager.Create(user, base64ImgString);

                    if (result.Succeeded)
                    {
                        //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        //string code = manager.GenerateEmailConfirmationToken(user.Id);
                        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                        //Configurating the Email Body using Created HTML Template
                        //string body = this.PopulateBody(user.UserName, callbackUrl);

                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                        Response.Redirect("~/Default.aspx");
                        //manager.SendEmail(user.Id, "Confirm your account", body);
                        //Response.Redirect("/Account/NewAccountCheckEmail");
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                }
                else
                {
                    ErrorMessage.Text = "Upload Status: Only JPEG files are available for upload";
                }
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
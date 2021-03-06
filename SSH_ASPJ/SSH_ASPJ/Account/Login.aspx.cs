﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace SSH_ASPJ.Account
{
    //https://www.codeproject.com/articles/8467/simple-asp-net-session-management-framework
    //https://weblogs.asp.net/anasghanem/programmatically-changing-the-session-id
    //http://stackoverflow.com/questions/11987579/how-to-generate-a-new-session-id
    //https://www.codeproject.com/Articles/331962/A-Beginner-s-Tutorial-on-ASP-NET-State-Management
    //https://www.codeproject.com/articles/32545/exploring-session-in-asp-net
    //  https://msdn.microsoft.com/en-us/library/tw292whz(v=vs.100).aspx Managing Users by using membership
    //http://stackoverflow.com/questions/15199415/how-to-create-session-in-asp-net-c-sharp-login-and-registration-memberprofile-p
    //http://www.c-sharpcorner.com/UploadFile/009464/how-to-make-a-login-form-using-session-in-Asp-Net-C-Sharp/
    //http://stackoverflow.com/questions/6409170/how-to-implement-login-session-in-asp-net-and-c-sharp
    //http://stackoverflow.com/questions/14326012/how-to-get-a-username-from-asplogin-to-store-in-a-session
    //Topic 3a: WEb app security Slide number 26
    //http://www.daveoncsharp.com/2009/08/creating-an-asp-net-login-screen/

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "RegistrationSelection";
            // Enable this once you have account confirmation enabled for password reset functionality
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string password = "";

                if (textPassword.Visible == true)
                {
                    password = Password.Text;
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
                        password = base64ImgString;
                    }
                    else
                    {
                        FailureText.Text = "Upload Status: Only JPEG files are available for upload";
                    }
                }

                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                //Require the user to have a confirmed email before they can login
                var user = manager.FindByName(userName.Text);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        FailureText.Text = "Invalid login attempt. You must have a confirmed email address.";
                        ErrorMessage.Visible = true;
                        ResendConfirm.Visible = true;
                    }
                    else
                    {
                        // This doen't count login failures towards account lockout
                        // To enable password failures to trigger lockout, change to shouldLockout: true
                        var result = signinManager.PasswordSignIn(userName.Text, Password.Text, RememberMe.Checked, shouldLockout: true);

                        switch (result)
                        {
                            case SignInStatus.Success:
                                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                                break;

                            case SignInStatus.LockedOut:
                                Response.Redirect("/Account/Lockout");
                                break;

                            case SignInStatus.RequiresVerification:
                                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                                Request.QueryString["ReturnUrl"],
                                                                RememberMe.Checked),
                                                  true);
                                break;

                            case SignInStatus.Failure:
                            default:
                                FailureText.Text = "Invalid login attempt";
                                ErrorMessage.Visible = true;
                                break;
                        }
                    }
                }
            }

            //var userStore = new UserStore<IdentityUser>();
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var user = userManager.Find(userName.Text, Password.Text);
            //if (user != null)
            //{
            //    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
            //    Response.Redirect("~/index.aspx");
            //}
            //else
            //{
            //    FailureText.Text = "Invalid Login Attempt";
            //    ErrorMessage.Visible = true;
            //}
        }

        protected void SendEmailConfirmationToken(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(userName.Text);
            if (user != null)
            {
                if (!user.EmailConfirmed)
                {
                    string code = manager.GenerateEmailConfirmationToken(user.Id);
                    string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    FailureText.Text = "Confirmation email sent. Please view the email and confirm your account.";
                    ErrorMessage.Visible = true;
                    ResendConfirm.Visible = false;
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
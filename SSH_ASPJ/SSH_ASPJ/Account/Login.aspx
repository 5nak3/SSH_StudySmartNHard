﻿<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSH_ASPJ.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Login using your school email</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="userName" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="userName" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                     <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PasswordSelection" CssClass="col-md-2 control-label">Type of Password</asp:Label>
            <div class="col-md-10">
                <asp:RadioButtonList ID="PasswordSelection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PasswordSelection_SelectedIndexChanged">
                    <asp:ListItem Text="Text Password" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Image Password" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordSelection"
                    CssClass="text-danger" ErrorMessage="This is required to choose a selection" />
            </div>
        </div>
                    <div id="textPassword" runat="server" visible="false">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                        </div>
                      <div id="imagePassword" runat="server" visible="false">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="imagePasswordControl" CssClass="col-md-2 control-label">Please choose an image</asp:Label>
                <div class="col-md-10">
                  <asp:FileUpload runat="server" id="imagePasswordControl" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="imagePasswordControl"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The image field is required." />
                </div>
            </div>
        </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                            <asp:Button runat="server" ID="ResendConfirm" OnClick="SendEmailConfirmationToken" Text="Resend confirmation" Visible="false" CssClass="'btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Enabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                     <%--Enable this once you have account confirmation enabled for password reset functionality--%>
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
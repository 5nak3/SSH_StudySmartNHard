﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="SSH_ASPJ.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="The username field is required" />
            </div>
        </div>
        <div class="form-group">
          <asp:Label runat="server" AssociatedControlID="fullName" CssClass="col-md-2 control-label">Full Name</asp:Label>
          <div class="col-md-10">
              <asp:TextBox runat="server" ID="fullName" CssClass="form-control" TextMode="SingleLine" />
              <asp:RequiredFieldValidator runat="server" ControlToValidate="fullName"
                    CssClass="text-danger" ErrorMessage="The Full Name field is required" />
          </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="userInstitution" CssClass="col-md-2 control-label">Your Institution</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="userInstitution" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="userInstitution"
                    CssClass="text-danger" ErrorMessage="The Instution field is required" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="userPhoneNumber" CssClass="col-md-2 control-label">Your Phone Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="userPhoneNumber" CssClass="form-control" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="userPhoneNumber"
                    CssClass="text-danger" ErrorMessage="The Phone Number field is required" />
            </div>
        </div>
        <!--
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
            -->
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
            
    </div>
</asp:Content>

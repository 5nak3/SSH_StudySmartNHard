<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MentorRegistration.aspx.cs" Inherits="SSH_ASPJ.Account.MentorRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:Label runat="server" AssociatedControlID="MentorEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MentorEmail" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MentorEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="mentorUsername" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="mentorUsername" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="mentorUsername"
                    CssClass="text-danger" ErrorMessage="The Username field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Full Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="mentorFullName" CssClass="form-control" TextMode="SingleLine" />
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="mentorFullName"
                    CssClass="text-danger" ErrorMessage="The Full Name field is required." />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MentorInstitution" CssClass="col-md-2 control-label">Your Institution</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MentorInstitution" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MentorInstitution"
                    CssClass="text-danger" ErrorMessage="The Instution field is required" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MentorPhoneNumber" CssClass="col-md-2 control-label">Your Phone Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MentorPhoneNumber" CssClass="form-control" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MentorPhoneNumber"
                    CssClass="text-danger" ErrorMessage="The Phone Number field is required" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MentorFOI" CssClass="col-md-2 control-label">Your Field of Industry</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="MentorFOI" runat="server" CssClass="ddl" BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" AutoPostBack="true">
                    <asp:ListItem Text="=SELECT=" Value="SELECT"></asp:ListItem>
                    <asp:ListItem Text="Information Technology" Value="IT"></asp:ListItem> 
                    <asp:ListItem Text="Business" Value="Business"></asp:ListItem>
                    <asp:ListItem Text="Interactive & Digital Media" Value="IDM"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MentorDesignation" CssClass="col-md-2 control-label">Your Designation</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MentorDesignation" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MentorDesignation"
                    CssClass="text-danger" ErrorMessage="The Designation field is required" />
            </div> 
        </div>
         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
          <br />  
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Change_Key.aspx.cs" Inherits="ASPJ.Admin.Change_Key" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/admin_general.css" rel="stylesheet" type="text/css" />
       <div class="container">
 <ul class="nav_admin">
  <li><a href="Console.aspx">Admin Settings</a><span class="arrow">»</span>
    <ul>
      <h4>Settings</h4>
      <hr />
        <li>
          <ul>
            <li><a href="Change_Key.aspx" >Change Key Pair</a></li>
            <li>New Service Account</li>
            <li>Manage Service Account</li>
          </ul>
      </li>
    </ul>
  </li>
  <li>Logging<span class="arrow">»</span>
      <ul>
      <h4>Logging</h4>
      <hr />
        <li>
          <ul>
            <li>View Log Files</li>
              <li>Analyse Log Files</li>
          </ul>
      </li>
    </ul>
  </li>
  <li>Alerts and Notifications <span class="arrow">»</span>
      <ul>
      <h4>Alerts and Notifications</h4>
      <hr />
        <li>
          <ul>
            <li>Alerts</li>
          </ul>
      </li>
    </ul>
  </li>
  <li>Monitor Users <span class="arrow">»</span></li>
</ul>
    <div class="admin_content" >
          <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
          <script src="http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="/Scripts/jsencrypt.js"></script>   
        <script type="text/javascript">  

        </script>
        <h2>Change Key Pair</h2>
        <p>Click the button below to change key pair. Your key will be downloaded.</p>
        <asp:Button ID="btnChange" runat="server" Text="Change Key" OnClick="changeKey" />
    </div>
    </div>
</asp:Content>

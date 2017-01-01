<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_Log.aspx.cs" Inherits="ASPJ.Admin.View_Log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/admin_general.css" rel="stylesheet" type="text/css" />
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
        <h1>Select Log file to view</h1>
        <p><asp:DropDownList ID="logList" runat="server"></asp:DropDownList></p>
        <asp:TextBox ID="query" runat="server" Width="615px"></asp:TextBox>
        <asp:Button ID="view" runat="server" Text="search" OnClick="getLogTable" />
        <asp:Table ID="LogTable" runat="server">
        </asp:Table>


    </div>
</asp:Content>

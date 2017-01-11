<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_Mentor.aspx.cs" Inherits="ASPJ.Add_Mentor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="MentorName" runat="server" Text="Label"></asp:Label>
    <br>
    <asp:TextBox ID="InvitationText" runat="server" TextMode="MultiLine" Height="78px" Width="544px" ></asp:TextBox>
    <br>
    <asp:Button ID="sendRequest" runat="server" Text="Request Mentor" OnClick="sendRequest_Clicked" />
</asp:Content>

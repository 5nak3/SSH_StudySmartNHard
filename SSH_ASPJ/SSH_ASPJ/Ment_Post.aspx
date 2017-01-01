<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ment_Post.aspx.cs" Inherits="ASPJ.Ment_Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center">
        <p><asp:Label ID="Label1" runat="server" Text="Start a Topic"></asp:Label></p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Topic: &nbsp"></asp:Label>
            <asp:TextBox ID="topic" runat="server" Width="427px" Height="16px"></asp:TextBox></p>
        <asp:TextBox ID="content" TextMode="MultiLine" runat="server" Height="137px" Width="470px"></asp:TextBox>
        <br><br>       
        <asp:Label ID="select" runat="server" Text="Select your mentor: "></asp:Label>
        <asp:DropDownList ID="MentorList" runat="server"></asp:DropDownList>
        <br><br />
        <p><asp:Button ID="post" runat="server" Text="Post" Width="74px" /></p>
    </div>
</asp:Content>

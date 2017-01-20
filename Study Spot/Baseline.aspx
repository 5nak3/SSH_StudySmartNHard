<%@ Page Title="Baseline" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Baseline.aspx.cs" Inherits="SSH_ASPJ.Study_Spot.Baseline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Do not run this file-->
    <div>
        <h3 class="header1">Study Spot Review</h3>
           <hr />

        <div >
            Post Title<br />
            <asp:TextBox ID="Review" runat="server" Height="282px" Width="1432px" style="overflow:auto" TextMode="MultiLine"></asp:TextBox>
            
            

            <br />
            <br />
            </div>
        

        <div>
            <asp:TextBox ID="CommentBox" runat="server" Width="1237px"></asp:TextBox>
            
            

        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
            
            

            <br />
            <br />
            Comment Title
            

            <br />
            <br />
            <asp:Panel ID="Comment1" runat="server">
                No comments have been posted.
            </asp:Panel>
            

        </div>




    </div>
</asp:Content>

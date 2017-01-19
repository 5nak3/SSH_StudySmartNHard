<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainReview.aspx.cs" Inherits="SSH_ASPJ.Study_Spot.MainReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="CSS/StudySpot.css" rel="stylesheet" type="text/css">
    
    <div>
        <h3 class="header1">Study Spot Review</h3>
           <hr />


        
        <p class="table">

        <asp:Table ID="Table1" runat="server" style="width:100%;border:1px solid black;background-color:azure;color:red">
            <asp:TableRow style="border:1px solid black">
                <asp:TableHeaderCell style="text-align:center;border:1px solid black">Current Areas</asp:TableHeaderCell>
            </asp:TableRow>
            <asp:TableRow ID="Original" style="border:1px solid black" runat="server">
                <asp:TableCell style="border:1px solid black">There is nothing to display here.</asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        </p>

        <asp:Button ID="Button1" runat="server" Text="Refresh" BorderColor="Green" Font-Bold="True" OnClick="Button1_Click" />


        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>


    </div>
    
</asp:Content>

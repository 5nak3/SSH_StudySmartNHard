<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mentorship.aspx.cs" Inherits="ASPJ.Mentorship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/mentorship.css" rel="stylesheet" type="text/css" />
    <style>
        .forumCell{
            border-bottom:1px solid #bbb;
            margin-bottom:20px;
            height:60px;
            background-color: hsl(0, 0%, 96%);
        }
        .forumHeader{
            background-color: hsl(206, 35%, 13%);
            color:white;
            padding:5px;
            height:40px;
            font:bold;
        }
        .postHeader{
            background-color: hsl(195, 73%, 58%);
            padding-top: 25px;
            padding-left: 5px;
            width: 90%;
            border-radius: 5px 5px 0px 0px;
            color:white;
        }
        .forum{
            width: 90%;
        }

    </style>
    <script type="text/javascript">
        $(document).ready(function() {

        });
    </script>

    <div class="content">
		<div id="post_content">
            
            <div class="postHeader">
                Forums
            </div>
            <asp:Table ID="forum" runat="server" CssClass="forum"></asp:Table>
		</div>
		<div id="other_content">
            
                <asp:Panel ID="mentPanel" runat="server"></asp:Panel>
                <asp:Panel ID="findMent" runat="server"></asp:Panel>
		</div>
</div>




        
    
    
</asp:Content>

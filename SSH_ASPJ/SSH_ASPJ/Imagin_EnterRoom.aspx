<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Imagin_EnterRoom.aspx.cs" Inherits="Imagin2.Imagin_EnterRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator ID="rev" runat="server"
    ControlToValidate="TextBox1"
    ErrorMessage="The <> tags are not allowed!"
    ValidationExpression="[^<>]*" />

    <br />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br />

    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

</asp:Content>

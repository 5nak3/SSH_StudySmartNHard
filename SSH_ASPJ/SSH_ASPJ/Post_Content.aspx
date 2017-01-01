<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Post_Content.aspx.cs" Inherits="ASPJ.Post_Content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/post_content.css" rel="stylesheet" type="text/css" />

    <asp:Button ID="reply" runat="server" Text="Reply Topic" />
        <asp:Panel ID="content" runat="server" CssClass="content">
            <div class="title">
            &nbsp;<asp:Label ID="title"  runat="server" Text="Title: "></asp:Label>
                </div>
        </asp:Panel>
    <script language="javascript" type="text/javascript">
    function pageLoad() {
        ShowPopup();
        setTimeout(HidePopup, 2000);
    }

    function ShowPopup() {
        $find('modalpopup').show();
        //$get('Button1').click();
    }

    function HidePopup() {
        $find('modalpopup').hide();
        //$get('btnCancel').click();
    }
</script>


        <ajaxToolKit:modalpopupextender id="ModalPopupExtender1" runat="server" 
	cancelcontrolid="btnCancel" 
	targetcontrolid="reply" popupcontrolid="postPanel" 
	popupdraghandlecontrolid="PopupHeader" drag="true" 
	backgroundcssclass="ModalPopupBG">
</ajaxToolKit:modalpopupextender>

<asp:panel id="postPanel" style="display: none" runat="server">
	<div class="postDiv">
                <div class="PopupHeader" id="PopupHeader">Reply to this Topic</div>
                <div class="PopupBody">
                    <asp:TextBox CssClass="replyBox" ID="replyContent" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div class="Controls">
                    <asp:Button ID="btnPost" runat="server" Text="Post" onClick="replyTopic"/>
                    <input id="btnCancel" type="button" value="Cancel" />
		</div>
        </div>
</asp:panel>



</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ASPJ.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <asp:Label ID="testLabel" runat="server" Text="TestLabel"></asp:Label>
    </p>
    <p>
        <asp:BulletedList ID="friendList" runat="server" DisplayMode="LinkButton" 
            OnClick="friendList1_Click">
    </asp:BulletedList>
    <div>
        

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
 <!--   <script src="http://code.jquery.com/jquery-1.9.1.js"></script>-->
            <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
       <script language="javascript" type="text/javascript">
            $(function () {
                $('#<%=searchFriendBox.ClientID%>').autocomplete({
                    source: function(request,response){
                        $.ajax({
                            url: "/searchFriend.asmx/GetLists",
                            data: "{'friend': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function(data){
                                response($.map(data.d,function(item){
                                    return {value: item}
                                }))
                            },
                            error: function(XMLHttpRequest, textStatus, errorThrown){
                                alert(textStatus);
                                alert(errorThrown);
                                alert(XMLHttpRequest);
                            }
                        })
                    }
                }
                    )
            })
        </script>
            <asp:TextBox ID="searchFriendBox" runat="server"></asp:TextBox>

        <asp:Button ID="addFriend" runat="server" Text="Add Friend" OnClick="addFriend_clicked"/>
        </div>
    <asp:Label ID="add_result" runat="server"  Text="" style="display: none;"></asp:Label>
    </p>
    
    <div class="container">
        <ul id="discussion">
        </ul>
    </div>
    <!--Reference the jQuery library. -->

    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.2.1.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
    //    var userID = <%=user%>;
        var userID = prompt("enter your userID");
        $(function () {
            
            // Declare a proxy to reference the hub. 
            var chat = $.connection.notificationHub;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (message) {
                // Html encode display name and message. 
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page. 
                $('#discussion').prepend('<li>' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
         //   $('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.  
      //      $('#message').focus();
            // Start the connection.
            $.connection.hub.qs = "userID="+userID;
            $.connection.hub.start().done(function () {
                chat.server.retrieveNotification(userID);
            });
            
        });
    </script>

</asp:Content>

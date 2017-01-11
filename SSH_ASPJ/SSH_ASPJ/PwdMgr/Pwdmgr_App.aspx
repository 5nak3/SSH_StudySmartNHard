<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pwdmgr_App.aspx.cs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Bootstrap Core CSS -->
    <title>SSH Password Manager</title>

    <div class="col-lg-12 text-center btm-mediummargin">
        <h1>Password Analysis Summary</h1>
    </div>

    <div class="row row-grid ">
        <div class="col-sm-3 text-center">
            <h5>All Accounts</h5>
            <div class="circleV circleV-border" id="allaccounts">
                <div class="circleV-inner">
                    <div class="score-text">
                        SOME TEXT
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-3 text-center">
            <h5>Weak Passwords</h5>
            <div class="circleV circleV-border" id="weakpass">
                <div class="circleV-inner">
                    <div class="score-text">
                        SOME TEXT
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-3 text-center">
            <h5>Invalid Access Attempts</h5>
            <div class="circleV circleV-border" id="invalidaccess">
                <div class="circleV-inner">
                    <div class="score-text">
                        SOME TEXT
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-3 text-center">
            <h5>Average Safety Level</h5>
            <div class="circleV circleV-border" id="safetylevel">
                <div class="circleV-inner">
                    <div class="score-text">
                        SOME TEXT
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <table class="table table-striped table-hover ">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Source</th>
                    <th>Username</th>
                    <th>Password</th>
                    <th>Safety Level</th>
                    <th>Recommended Action</th>
                    <th>Last Used</th>
                    <th>Auto Login</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPassword" runat="server">
        <ItemTemplate>
            <tr class="info">
                <td>
                    <asp:Label ID= "lblSource" runat="server" Text='<%# Eval("source") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblUsername" runat="server" Text='<%# Eval("userName") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblPassword" runat="server" Text='<%# Eval("password") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblSafetyLevel" runat="server" Text='<%# Eval("safetyLvl") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblRecommendedAction" runat="server" Text='<%# Eval("source") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblLastUsed" runat="server" Text='<%# Eval("lastUsed") %>'/>
                </td>
                <td>
                    <asp:Label ID= "lblAutoLogin" runat="server" Text='<%# Eval("source") %>'/>
                </td>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
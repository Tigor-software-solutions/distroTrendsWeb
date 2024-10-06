<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="distroTrend.Home" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cssPager td {
            padding-left: 4px;
            padding-right: 4px;
        }
    </style>
    <div>
        <span>The Top 5 distros for <asp:DropDownList ID="ddlUserType" runat="server"></asp:DropDownList> are:-</span>
    </div>
    <div>
        <br />
        <asp:GridView ID="gvMain" runat="server" CssClass="table" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvMain_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" ReadOnly="True" SortExpression="Rank" />
                <asp:ImageField DataImageUrlField="ImageURL" ItemStyle-Width="50px" ControlStyle-Width="25" ControlStyle-Height="25" />
                <asp:HyperLinkField DataNavigateUrlFields="Name" DataTextField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Points" HeaderText="Points" ReadOnly="True" SortExpression="Points" />
            </Columns>
            <PagerStyle CssClass="cssPager" />
        </asp:GridView>
    </div>
</asp:Content>

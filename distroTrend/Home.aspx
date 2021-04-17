<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="distroTrend.Home" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Rank" HeaderText="Rank" ReadOnly="True" SortExpression="Rank" />
                <asp:HyperLinkField DataNavigateUrlFields="Name" DataTextField="Name" HeaderText="Name" />
                <!--Hide Description Columns-->
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

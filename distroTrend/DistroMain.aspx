<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistroMain.aspx.cs" Inherits="distroTrend.DistroMain" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <br />
        <br />
        <dl class="dl-horizontal">
            <dt>Name</dt>
            <dd>
                <asp:Label ID="lblName" runat="server"></asp:Label></dd>
        </dl>
        <dl class="dl-horizontal">
            <dt>Description</dt>
            <dd>
                <asp:Label ID="lblDescription" runat="server"></asp:Label></dd>
        </dl>
        <dl class="dl-horizontal">
            <dt>URL</dt>
            <dd>
                <asp:HyperLink ID="hlUrl" runat="server" Target="_blank"></asp:HyperLink></dd>
        </dl>
    </div>

</asp:Content>

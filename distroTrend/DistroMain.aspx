<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistroMain.aspx.cs" Inherits="distroTrend.DistroMain" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
            <br />
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblDescription" runat="server"></asp:Label>
            <br />
            <asp:HyperLink ID="hlUrl" runat="server" Target="_blank"></asp:HyperLink>
            <br />
        </div>
    
</asp:Content>

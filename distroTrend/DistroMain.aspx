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
        <dl class="dl-horizontal">
            <dt></dt>
            <dd>
                <asp:ListView ID="lvEditions" GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" runat="server">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>Editions
                                </th>
                            </tr>
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>

                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'>   
                            </asp:Label>
                        </td>
                    </ItemTemplate>
                </asp:ListView>
                <asp:ListView ID="lvRelease" GroupPlaceholderID="groupPlaceHolderRelease1" ItemPlaceholderID="itemPlaceHolderRelease1" runat="server">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>Releases
                                </th>
                            </tr>
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolderRelease1"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolderRelease1"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'>   
                            </asp:Label>
                        </td>
                    </ItemTemplate>
                </asp:ListView>
            </dd>
        </dl>
    </div>
</asp:Content>

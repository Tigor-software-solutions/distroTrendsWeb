<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistroMain.aspx.cs" Inherits="distroTrend.DistroMain" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label for="ddlDistro">The selected distro is :</label>
        <asp:DropDownList ID="ddlDistro" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistro_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div style="width: 70%; float:left">
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" class="btn btn-primary"></asp:Button>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" class="btn btn-primary"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" class="btn btn-default"></asp:Button>
        <br />
        <dl class="dl-horizontal">
            <dt>Name</dt>
            <dd>
                <asp:Label ID="lblName" runat="server"></asp:Label>
                <asp:Image ID="imgLogo" runat="server" />
            </dd>
        </dl>
        <dl class="dl-horizontal">
            <dt>Description</dt>
            <dd>
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" Visible="false"></asp:TextBox>
            </dd>
        </dl>
        <dl class="dl-horizontal">
            <dt>URL</dt>
            <dd>
                <asp:HyperLink ID="hlUrl" runat="server" Target="_blank"></asp:HyperLink>
                <asp:TextBox ID="txtUrl" runat="server" Visible="false"></asp:TextBox>
            </dd>
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
    <div style="width: 30%; float:right">
        <table>
            <tr>
                <td>
                    <span>Usability</span>
                </td>
            </tr>
            <tr>
                <td>
                    <ajaxToolkit:Rating ID="RatingUsability" runat="server" CurrentRating="0" MaxRating="5" 
                        EmptyStarCssClass="emptypng" FilledStarCssClass="smileypng" StarCssClass="smileypng" 
                        WaitingStarCssClass="donesmileypng"></ajaxToolkit:Rating>
                </td>
                <td>
                    <asp:Label ID="lblRatingUsability" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Stability</span>
                </td>
            </tr>
            <tr>
                <td>
                    <ajaxToolkit:Rating ID="RatingStability" runat="server" CurrentRating="0" MaxRating="5" 
                        EmptyStarCssClass="emptypng" FilledStarCssClass="smileypng" StarCssClass="smileypng" 
                        WaitingStarCssClass="donesmileypng"></ajaxToolkit:Rating>
                </td>
                <td>
                    <asp:Label ID="lblRatingStability" runat="server" Text=""></asp:Label>                    
                </td>
            </tr>
        </table>

        <%--<span>User Friendliness</span>--%>

        <asp:Button ID="btnRating" runat="server" Text="Rate!" OnClick="btnRating_Click" />
    </div>
    <style type="text/css">
 .emptypng { background-image: url(images/icons-star-empty.png); width: 48px; height: 48px; }
 .smileypng { background-image: url(images/icons-star-filled.png); width: 48px; height: 48px; }
 .donesmileypng { background-image: url(images/icons-star-filled.png); width: 48px; height: 48px; }
</style>
</asp:Content>

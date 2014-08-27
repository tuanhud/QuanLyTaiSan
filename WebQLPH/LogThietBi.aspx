<%@ Page Language="C#" MasterPageFile="~/PopupMasterPage.Master" AutoEventWireup="true" CodeBehind="LogThietBi.aspx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.LogThietBi" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Log thiết bị</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
        <div class="row">
            <div class="alert alert-danger" role="alert">
                <span class="glyphicon glyphicon-exclamation-sign"></span>
                <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
        <table class="table table-bordered table-striped">
            <tbody>
                <tr>
                    <td>
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                Log
                            </div>
                            <% if (RepeaterDanhSachLogThietBi.Items.Count == 0)
                               { %>   
                            <div class="panel-body">
                                <asp:Label ID="Label_DanhSachLogThietBi" runat="server"></asp:Label>
                            </div>
                            <% } else { %>
                            <table class="table table-bordered table-striped">
                                <thead class="centered">
                                    <tr>
                                        <th>#</th>
                                        <th>Tên</th>
                                        <th>Tình trạng</th>
                                        <th>Số lượng</th>
                                        <th>Ghi chú</th>
                                        <th>Quản trị viên</th>
                                        <th>Phòng</th>
                                        <th>Ngày</th>
                                    </tr>
                                </thead>
                                <tbody class="centered">
                                    <asp:Repeater ID="RepeaterDanhSachLogThietBi" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachLogThietBi.CurrentPage - 1)*CollectionPagerDanhSachLogThietBi.PageSize) %></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("ten") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("tinhtrang") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("soluong") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("ghichu") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("quantrivien") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("phong") %></a></td>
                                                <td><a href="<%# Eval("url") %>"><%# Eval("ngay") %></a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <% } %>
                        </div>
                        <div class="leftCollectionPager">
                            <div class="CollectionPager">
                                <cp:CollectionPager ID="CollectionPagerDanhSachLogThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="3" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                            </div>
                        </div>
                    </td>
                    <td>
                        <dx:ASPxImageSlider ID="ASPxImageSlider_Log" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>

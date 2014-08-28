<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.SuCo.ucSuCo_Mobile" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
    <asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Chọn phòng
            </div>
            <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel_DanhSachSuCo" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_DanhSachSuCoTitle" runat="server" Text="Danh sách sự cố"></asp:Label>
            </div>
            <% if (RepeaterSuCo.Items.Count == 0)
               { %>
            <div class="panel-body">
                <asp:Label ID="Label_DanhSachSuCo" runat="server" Text="Phòng chưa có sự cố"></asp:Label>
            </div>
            <% }
               else
               { %>
            <table class="table table-bordered table-striped table-hover">
                <thead class="centered">
                    <tr>
                        <th>#</th>
                        <th>Tên sự cố</th>
                        <th>Tình trạng</th>
                        <th>Mô tả</th>
                        <th>Ngày</th>
                    </tr>
                </thead>
                <tbody class="centered">
                    <asp:Repeater ID="RepeaterSuCo" runat="server">
                        <ItemTemplate>
                            <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachSuCo.CurrentPage - 1)*CollectionPagerDanhSachSuCo.PageSize) %></td>
                                <td><%# Eval("ten") %></td>
                                <td><%# Eval("tinhtrang") %></td>
                                <td><%# Eval("mota") %></td>
                                <td><%# Eval("ngay") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <% } %>
        </div>

        <div class="leftCollectionPager">
            <div class="CollectionPager">
                <cp:CollectionPager ID="CollectionPagerDanhSachSuCo" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
            </div>
        </div>
        <asp:Button ID="ButtonBack_DanhSachSuCo" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachSuCo_Click" />
    </asp:Panel>
    <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label>
            </div>

            <div class="panel-body">
                <table class="table table-bordered">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <div class="center200">
                                    <dx:ASPxImageSlider ID="ASPxImageSlider_SuCo" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"></dx:ASPxImageSlider>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 120px" class="warning">Tên sự cố</th>
                            <td>
                                <asp:Label ID="Label_TenSuCo" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th class="warning">Tình trạng</th>
                            <td>
                                <asp:Label ID="Label_TinhTrang" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th class="warning">Ngày tạo</th>
                            <td>
                                <asp:Label ID="Label_NgayTao" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th class="warning">Mô tả</th>
                            <td>
                                <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <asp:Button ID="ButtonBack_SuCo" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_SuCo_Click" />
    </asp:Panel>
</asp:Panel>

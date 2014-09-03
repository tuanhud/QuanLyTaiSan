<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.Phong.ucPhong_Mobile" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_TreeListViTri" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Chọn vị trí cần xem
        </div>
        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
    </div>
</asp:Panel>

<asp:Panel ID="Panel_DanhSachPhong" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_DanhSachPhong" runat="server" Text="Danh sách phòng"></asp:Label>
        </div>
        <% if (RepeaterDanhSachPhong.Items.Count == 0)
           { %>
        <div class="panel-body">Vị trí này không có phòng</div>
        <% }
           else
           { %>
        <table class="table table-bordered table-striped table-hover">
            <thead class="centered">
                <tr>
                    <th>#</th>
                    <th>Tên phòng</th>
                    <th>Mô tả</th>
                    <th>Nhân viên phụ trách</th>
                </tr>
            </thead>
            <tbody class="centered">
                <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                    <ItemTemplate>
                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachPhong.CurrentPage - 1)*CollectionPagerDanhSachPhong.PageSize) %></td>
                            <td><%# Eval("ten") %></td>
                            <td><%# Eval("subid") %></td>
                            <td><%# Eval("nhanvienpt") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <% } %>
    </div>

    <div class="leftCollectionPager">
        <div class="CollectionPager">
            <cp:CollectionPager ID="CollectionPagerDanhSachPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
        </div>
    </div>
    <asp:Button ID="ButtonBack_DanhSachPhong" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachPhong_Click" />
</asp:Panel>

<asp:Panel ID="Panel_ThongTinPhong" runat="server" Visible="False">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin phòng"></asp:Label>
        </div>

        <div class="panel-body">
            <table class="table table-bordered">
                <tbody>
                    <tr>
                        <td colspan="2">
                            <div class="center200">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_Phong" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Mã phòng</th>
                        <td>
                            <asp:Label ID="Label_MaPhong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Tên phòng</th>
                        <td>
                            <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Vị trí</th>
                        <td>
                            <asp:Label ID="Label_ViTriPhong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Mô tả</th>
                        <td>
                            <asp:Label ID="Label_MoTaPhong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Nhân viên phụ trách</th>
                        <td>
                            <asp:Label ID="Label_NhanVienPhuTrach" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTinNhanVien" runat="server" Text="Thông tin nhân viên"></asp:Label>
        </div>

        <div class="panel-body">
            <asp:Panel ID="Panel_NhanVienPT" runat="server" Visible="False">
                <table class="table table-bordered">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <div class="center200">
                                    <dx:ASPxImageSlider ID="ASPxImageSlider_NhanVienPT" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 120px" class="warning">Mã nhân viên</th>
                            <td>
                                <asp:Label ID="Label_MaNhanVien" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 120px" class="warning">Họ tên</th>
                            <td>
                                <asp:Label ID="Label_HoTen" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 120px" class="warning">Số điện thoại</th>
                            <td>
                                <asp:Label ID="Label_SoDienThoai" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Label ID="Label_NhanVienPT" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
    <asp:Button ID="ButtonBack_ThongTinPhong" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_ThongTinPhong_Click" />
</asp:Panel>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.NhanVien.ucNhanVien_Mobile" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_BreadCrumb.ascx" TagPrefix="uc" TagName="ucNhanVien_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucNhanVien_BreadCrumb runat="server" ID="_ucNhanVien_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="PanelThongTinNhanVienPhuTrach" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">Thông tin nhân viên
                    </h3>
                    <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>Mã nhân viên:</td>
                                <td>
                                    <asp:Label ID="Label_MaNhanVien" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Họ tên:</td>
                                <td>
                                    <asp:Label ID="Label_HoTen" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Số điện thoại:</td>
                                <td>
                                    <asp:Label ID="Label_SoDienThoai" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <% if (RepeaterDanhSachPhong.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        Không có phòng nào
                    </div>
                    <% }
                       else
                       {%>
                    <h3 class="title_blue fix">Danh sách phòng</h3>
                    <ul class="list-group">
                        <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                            <ItemTemplate>
                                <a href="javascript:;" class="list-group-item" onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                    <%# Eval("ten") %>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
                    <%} %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="PanelDanhSachNhanVienPhuTrach" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <% if (RepeaterDanhSachNhanVien.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        Chưa có nhân viên
                    </div>
                    <% }
                       else
                       {%>
                    <h3 class="title_blue fix">Danh sách nhân viên</h3>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Mã nhân viên</th>
                                <th>Họ tên</th>
                                <th>Số điện thoại</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterDanhSachNhanVien" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachNhanVien.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("subid") %></td>
                                        <td><%# Eval("hoten") %></td>
                                        <td><%# Eval("sodienthoai") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachNhanVien" />
                    <%} %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

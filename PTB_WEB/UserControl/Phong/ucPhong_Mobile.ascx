<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhong_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucPhong_BreadCrumb runat="server" ID="ucPhong_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_TreeListViTri" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="Panel_DanhSachPhong" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <% if (RepeaterDanhSachPhong.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        Vị trí này không có phòng
                    </div>
                    <% }
                       else
                       { %>
                    <h3 class="title_blue fix">Danh sách phòng</h3>
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
                                        <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("ten") %></td>
                                        <td><%# Eval("subid") %></td>
                                        <td><%# Eval("nhanvienpt") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
                    <% } %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="Panel_ThongTinPhong" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">Thông tin phòng
                    </h3>
                    <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile_Phong" />
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td style="width: 120px">Mã phòng:</td>
                                <td>
                                    <asp:Label ID="Label_MaPhong" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Tên phòng:</td>
                                <td>
                                    <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Vị trí:</td>
                                <td>
                                    <asp:Label ID="Label_ViTriPhong" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Mô tả:</td>
                                <td>
                                    <asp:Label ID="Label_MoTaPhong" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Nhân viên phụ trách:</td>
                                <td>
                                    <asp:Label ID="Label_NhanVienPhuTrach" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <h3 class="title_green fix">Thông tin nhân viên
                    </h3>
                    <asp:Panel ID="Panel_NhanVienPT" runat="server" Visible="False">
                        <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile_NhanVienPT" />
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td style="width: 120px">Mã nhân viên:</td>
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
                    </asp:Panel>
                    <asp:Label ID="Label_NhanVienPT" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

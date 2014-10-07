<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDonViTaiSan_Mobile.ascx.cs" Inherits="TSCD_WEB.UserControl.DonViTaiSan.ucDonViTaiSan_Mobile" %>

<%@ Register Src="~/UserControl/CollectionPager/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/DonViTaiSan/ucDonViTaiSan_BreadCrumb.ascx" TagPrefix="uc" TagName="ucDonViTaiSan_BreadCrumb" %>
<%@ Register Src="~/UserControl/TreeViTri/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/DangNhap/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>


<uc:ucDonViTaiSan_BreadCrumb runat="server" ID="ucDonViTaiSan_BreadCrumb" />

<table class="table largetable">
    <tbody>
        <tr id="DangNhap" runat="server" visible="false">
            <td>
                <uc:ucDangNhap runat="server" ID="ucDangNhap" />
            </td>
        </tr>
        <tr id="KhongCoDuLieu" runat="server" visible="false">
            <td>
                <uc:ucDanger runat="server" ID="ucDanger_KhongCoDuLieu" />
            </td>
        </tr>
        <tr id="TreeViTri" runat="server" visible="false">
            <td>
                <uc:ucTreeViTri runat="server" ID="ucTreeViTri" />
            </td>
        </tr>
        <tr id="KhongCoTaiSan" runat="server" visible="false">
            <td>
                <uc:ucWarning runat="server" ID="ucWarning_KhongCoTaiSan" />
            </td>
        </tr>
        <tr id="DanhSach" runat="server" visible="false">
            <td>
                <h3 class="title_blue fix">Danh sách tài sản</h3>
                <table class="table table-bordered table-striped table-hover">
                    <thead class="centered">
                        <tr>
                            <th>#</th>
                            <th>Tên TSCD</th>
                            <th>Loại tài sản</th>
                        </tr>
                    </thead>
                    <tbody class="centered">
                        <asp:Repeater ID="RepeaterDanhSachTaiSan" runat="server">
                            <ItemTemplate>
                                <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idTaiSan.ToString()?" class=\"focusrow\"":"" %>>
                                    <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachTaiSan.CollectionPager_Object.PageSize) %></td>
                                    <td><%# Eval("ten") %></td>
                                    <td><%# Eval("loai") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachTaiSan" />
            </td>
        </tr>
        <tr id="ThongTin" runat="server" visible="false">
            <td>
                <h3 class="title_green fix">Thông tin tài sản</h3>
                <table class="table table-striped">
                    <tbody>
                        <tr>
                            <td style="width: 120px">Ngày sử dụng:</td>
                            <td>
                                <asp:Label ID="Label_NgaySuDung" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Số hiệu:</td>
                            <td>
                                <asp:Label ID="Label_SoHieu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Ngày tháng:</td>
                            <td>
                                <asp:Label ID="Label_NgayThang" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Tên tài sản:</td>
                            <td>
                                <asp:Label ID="Label_TenTaiSan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Đơn vị tính:</td>
                            <td>
                                <asp:Label ID="Label_DonViTinh" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Số lượng:</td>
                            <td>
                                <asp:Label ID="Label_SoLuong" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Đơn giá:</td>
                            <td>
                                <asp:Label ID="Label_DonGia" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Thành tiền:</td>
                            <td>
                                <asp:Label ID="Label_ThanhTien" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Nước sản xuất:</td>
                            <td>
                                <asp:Label ID="Label_NuocSanXuat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Nguồn gốc:</td>
                            <td>
                                <asp:Label ID="Label_NguonGoc" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Tình trạng:</td>
                            <td>
                                <asp:Label ID="Label_TinhTrang" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Phòng:</td>
                            <td>
                                <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Vị trí:</td>
                            <td>
                                <asp:Label ID="Label_ViTri" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Dơn vị quản lý:</td>
                            <td>
                                <asp:Label ID="Label_DonViQuanLy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Đơn vị sử dụng:</td>
                            <td>
                                <asp:Label ID="Label_DonViSuDung" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Ghi chú:</td>
                            <td>
                                <asp:Label ID="Label_GhiChu" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.Phong.ucPhong_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhong_BreadCrumb" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <uc:ucPhong_BreadCrumb runat="server" ID="ucPhong_BreadCrumb" />
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
                                <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
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
        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
        <asp:Button ID="ButtonBack_DanhSachPhong" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachPhong_Click" />
    </asp:Panel>

    <asp:Panel ID="Panel_ThongTinPhong" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin phòng"></asp:Label>
            </div>

            <div class="panel-body">
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
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinNhanVien" runat="server" Text="Thông tin nhân viên"></asp:Label>
            </div>

            <div class="panel-body">
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
            </div>
        </div>
        <asp:Button ID="ButtonBack_ThongTinPhong" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_ThongTinPhong_Click" />
    </asp:Panel>
</asp:Panel>

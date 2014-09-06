<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.PhongThietBi.ucPhongThietBi_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_TreeListViTri" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Chọn phòng cần xem
        </div>
        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
    </div>
</asp:Panel>

<asp:Panel ID="Panel_DanhSachThietBi" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_DanhSachThietBiTitle" runat="server" Text="Danh sách thiết bị"></asp:Label>
        </div>
        <% if (RepeaterDanhSachThietBi.Items.Count == 0)
           { %>
        <div class="panel-body">
            <asp:Label ID="Label_DanhSachThietBi" runat="server"></asp:Label>
        </div>
        <% }
           else
           { %>
        <table class="table table-bordered table-striped table-hover">
            <thead class="centered">
                <tr>
                    <th>#</th>
                    <th>Tên</th>
                    <th>Tình trạng</th>
                    <th>Số lượng</th>
                    <th>Xem Log</th>
                </tr>
            </thead>
            <tbody class="centered">
                <asp:Repeater ID="RepeaterDanhSachThietBi" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("soluong") %></td>
                            <td>
                                <button class="btn btn-default" onclick="location.href='<%# Eval("urlLog") %>'; return false;">Xem log</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <% } %>
    </div>
    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
    <asp:Button ID="ButtonBack_DanhSachThietBi" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_DanhSachThietBi_Click" />
</asp:Panel>

<asp:Panel ID="Panel_ThietBi" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
        </div>
        <div class="panel-body">
            <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
            <table class="table table-bordered">
                <tbody>
                    <tr>
                        <td style="width: 120px">Mã thiết bị:</td>
                        <td>
                            <asp:Label ID="Label_MaThietBi" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Tên thiết bị:</td>
                        <td>
                            <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Loại thiết bị:</td>
                        <td>
                            <asp:Label ID="Label_LoaiThietBi" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Kiểu quản lý:</td>
                        <td>
                            <asp:Label ID="Label_KieuQuanLy" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Thuộc phòng:</td>
                        <td>
                            <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="Panel_NgayMua" runat="server" Visible="False">
                        <tr>
                            <td>Ngày mua:</td>
                            <td>
                                <asp:Label ID="Label_NgayMua" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td>Ngày lắp:</td>
                        <td>
                            <asp:Label ID="Label_NgayLap" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Mô tả:</td>
                        <td>
                            <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Xem log:</td>
                        <td>
                            <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:Button ID="ButtonBack_ThietBi" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="ButtonBack_ThietBi_Click" />
</asp:Panel>

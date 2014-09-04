<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.NhanVien.ucNhanVien_Mobile" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/NhanVien/ucNhanVien_BreadCrumb.ascx" TagPrefix="uc" TagName="ucNhanVien_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucNhanVien_BreadCrumb runat="server" ID="_ucNhanVien_BreadCrumb" />
    <asp:Panel ID="PanelThongTinNhanVienPhuTrach" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
            </div>
            <div class="panel-body">
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
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                Danh sách phòng
            </div>

            <% if (RepeaterDanhSachPhong.Items.Count == 0)
               { %>
            <div class="panel-body">Không có phòng nào</div>
            <% }
               else
               {%>
            <ul class="list-group">
                <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                    <ItemTemplate>
                        <li class="list-group-item"><%# Eval("ten") %></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <%} %>
        </div>

        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
        <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
    </asp:Panel>

    <asp:Panel ID="PanelDanhSachNhanVienPhuTrach" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Danh sách nhân viên
            </div>

            <% if (RepeaterDanhSachNhanVien.Items.Count == 0)
               { %>
            <div class="panel-body">Chưa có nhân viên</div>
            <% }
               else
               {%>
            <table class="table table-bordered table-striped table-hover">
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
            <%} %>
        </div>

        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachNhanVien" />
    </asp:Panel>
</asp:Panel>

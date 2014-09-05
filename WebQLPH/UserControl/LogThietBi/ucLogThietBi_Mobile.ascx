<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogThietBi_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.LogThietBi.ucLogThietBi_Mobile" %>

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

<asp:Panel ID="Panel_DanhSachLog" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_LogThietBi" runat="server" Text="Log"></asp:Label>
        </div>
        <% if (RepeaterDanhSachLogThietBi.Items.Count == 0)
           { %>
        <div class="panel-body">
            <asp:Label ID="Label_DanhSachLogThietBi" runat="server"></asp:Label>
        </div>
        <% }
           else
           { %>
        <table class="table table-bordered table-striped table-hover">
            <thead class="centered">
                <tr>
                    <th>#</th>
                    <th>Tình trạng</th>
                    <th>Số lượng</th>
                    <th>Phòng</th>
                    <th>Ngày</th>
                </tr>
            </thead>
            <tbody class="centered">
                <asp:Repeater ID="RepeaterDanhSachLogThietBi" runat="server">
                    <ItemTemplate>
                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                            <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.PageSize) %></td>
                            <td><%# Eval("tinhtrang") %></td>
                            <td><%# Eval("soluong") %></td>
                            <td><%# Eval("phong") %></td>
                            <td><%# Eval("ngay") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <% } %>
    </div>
    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachLogThietBi" />
</asp:Panel>

<asp:Panel ID="Panel_ThongTinLog" runat="server" Visible="false">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin nhân viên"></asp:Label>
        </div>
        <div class="panel-body">
            <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
            <table class="table table-striped">
                <tbody>
                    <tr>
                        <td style="width: 120px">Tên thiết bị:</td>
                        <td>
                            <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Tình trạng:</td>
                        <td>
                            <asp:Label ID="Label_TinhTrang" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Số lượng:</td>
                        <td>
                            <asp:Label ID="Label_SoLuong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Phòng:</td>
                        <td>
                            <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày:</td>
                        <td>
                            <asp:Label ID="Label_Ngay" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Người thực hiện:</td>
                        <td>
                            <asp:Label ID="Label_QuanTriVien" runat="server"></asp:Label>
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
        </div>
    </div>
    <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" Width="100px" OnClick="Button_Back_Click" />
</asp:Panel>

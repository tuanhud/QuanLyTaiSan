<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogThietBi_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.LogThietBi.ucLogThietBi_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>
<%@ Register Src="~/UserControl/LogThietBi/ucLogThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucLogThietBi_BreadCrumb" %>

<uc:ucLogThietBi_BreadCrumb runat="server" ID="_ucLogThietBi_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_DanhSachLog" runat="server" Visible="false">

    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <% if (RepeaterDanhSachLogThietBi.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_DanhSachLogThietBi" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <h3 class="title_blue fix">
                        <asp:Label ID="Label_LogThietBi" runat="server" Text="Log"></asp:Label>
                    </h3>
                    <asp:HyperLink ID="HyperLinkXemLogTheoThietBi" CssClass="pull-right" runat="server">Log theo Thiết bị</asp:HyperLink>
                    <asp:HyperLink ID="HyperLinkXemLogTheoPhong" CssClass="pull-right" runat="server" Visible="false">Log theo phòng</asp:HyperLink>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Tình trạng</th>
                                <th>Số lượng</th>
                                <th>Phòng</th>
                                <th>Ngày</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterDanhSachLogThietBi" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachLogThietBi.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("tinhtrang") %></td>
                                        <td><%# Eval("soluong") %></td>
                                        <td><%# Eval("phong") %></td>
                                        <td><%# Eval("ngay") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachLogThietBi" />
                    <% } %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

<asp:Panel ID="Panel_ThongTinLog" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin nhân viên"></asp:Label>
                    </h3>
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
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
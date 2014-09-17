<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogSuCo_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.LogSuCo.ucLogSuCo_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/LogSuCo/ucLogSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucLogSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucLogSuCo_BreadCrumb runat="server" ID="ucLogSuCo_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_DanhSachLog" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <% if (RepeaterDanhSachLogSuCo.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_DanhSachLogSuCo" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <h3 class="title_blue fix">
                        <asp:Label ID="Label_LogSuCo" runat="server" Text="Log"></asp:Label>
                    </h3>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Tình trạng</th>
                                <th>Phòng</th>
                                <th>Ngày</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterDanhSachLogSuCo" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("tinhtrang") %></td>
                                        <td><%# Eval("phong") %></td>
                                        <td><%# Eval("ngay") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachSuCo" />
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
                                <td>Tên sự cố:</td>
                                <td>
                                    <asp:Label ID="Label_TenSuCo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Tình trạng:</td>
                                <td>
                                    <asp:Label ID="Label_TinhTrang" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Ngày:</td>
                                <td>
                                    <asp:Label ID="Label_Ngay" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Phòng:</td>
                                <td>
                                    <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Quản trị viên:</td>
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
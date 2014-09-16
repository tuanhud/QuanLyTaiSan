<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogSuCo_Web.ascx.cs" Inherits="PTB_WEB.UserControl.LogSuCo.ucLogSuCo_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_LogSuCo" runat="server" Text="Log"></asp:Label></h3>
                    <% if (RepeaterDanhSachLogSuCo.Items.Count == 0)
                       { %>
                    <div class="panel-body">
                        <asp:Label ID="Label_DanhSachLogSuCo" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
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
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idLog.ToString()?" class=\"focusrow\"":"" %>>
                                        <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachLogSuCo.CollectionPager_Object.PageSize) %></td>
                                        <td><%# Eval("tinhtrang") %></td>
                                        <td><%# Eval("phong") %></td>
                                        <td><%# Eval("ngay") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <% } %>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachLogSuCo" />
                </td>
                <td style="width: 400px">
                    <h3 class="title_blue fix"><asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin nhân viên"></asp:Label></h3>
                    <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td style="width: 120px">Tên sự cố:</td>
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

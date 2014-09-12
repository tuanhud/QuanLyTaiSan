<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogThietBi_Web.ascx.cs" Inherits="PTB_WEB.UserControl.LogThietBi.ucLogThietBi_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
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

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table largetable">
        <tbody>
            <tr>
                <td class="border_right">
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_LogThietBi" runat="server" Text="Log"></asp:Label>
                    </h3>
                    <asp:HyperLink ID="HyperLinkXemLogTheoThietBi" CssClass="pull-right" runat="server">Log theo Thiết bị</asp:HyperLink>
                    <asp:HyperLink ID="HyperLinkXemLogTheoPhong" CssClass="pull-right" runat="server" Visible="false">Log theo phòng</asp:HyperLink>
                    <% if (RepeaterDanhSachLogThietBi.Items.Count == 0)
                       { %>
                    <div class="panel-body">
                        <asp:Label ID="Label_DanhSachLogThietBi" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead>
                            <tr>
                                <th class="tdcenter">#</th>
                                <th>Tình trạng</th>
                                <th>Số lượng</th>
                                <th class="tdcenter">Phòng</th>
                                <th>Ngày</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterDanhSachLogThietBi" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idLog.ToString()?" class=\"focusrow\"":"" %>>
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
                    <% } %>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachLogThietBi" />
                </td>
                <td style="width: 400px">
                    <h3 class="title_blue fix">
                        <asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin log"></asp:Label>
                    </h3>
                    <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
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

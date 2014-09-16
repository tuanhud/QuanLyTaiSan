<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.SuCo.ucSuCo_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
    <asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
        <table class="table largetable">
            <tbody>
                <tr>
                    <td style="width: 210px" class="border_right">
                        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel_DanhSachSuCo" runat="server" Visible="False">
        <table class="table largetable">
            <tbody>
                <tr>
                    <td>
                        <h3 class="title_blue fix">
                            <asp:Label ID="Label_DanhSachSuCoTitle" runat="server" Text="Danh sách sự cố"></asp:Label>
                        </h3>
                        <% if (RepeaterSuCo.Items.Count == 0)
                           { %>
                        <div class="panel-body">
                            <asp:Label ID="Label_DanhSachSuCo" runat="server" Text="Phòng chưa có sự cố"></asp:Label>
                        </div>
                        <% }
                           else
                           { %>
                        <table class="table table-bordered table-striped table-hover valign_middle">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Tên sự cố</th>
                                    <th>Tình trạng</th>
                                    <th>Log</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterSuCo" runat="server">
                                    <ItemTemplate>
                                        <tr <%# Eval("id").ToString() == idSuCo.ToString()?" class=\"focusrow\"":"" %>>
                                            <td class="tdcenter" onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachSuCo.CollectionPager_Object.PageSize) %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                            <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                            <td class="tdcenter">
                                                <button class="btn btn-default" onclick="location.href='<%# Eval("urlLog") %>'; return false;"><span class="glyphicon glyphicon-tasks"></span></button>
                                            </td>
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
    <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
        <table class="table largetable">
            <tbody>
                <tr>
                    <td>
                        <h3 class="title_green fix">
                            <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label>
                        </h3>
                        <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
                        <table class="table table-striped">
                            <tbody>
                                <tr>
                                    <td>Tên sự cố:</td>
                                    <td>
                                        <asp:Label ID="Label_TenSuCo" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tình trạng:</td>
                                    <td>
                                        <asp:Label ID="Label_TinhTrang" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ngày tạo:</td>
                                    <td>
                                        <asp:Label ID="Label_NgayTao" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Mô tả:</td>
                                    <td>
                                        <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdcenter">
                                        <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Panel>

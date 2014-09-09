<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Web.ascx.cs" Inherits="PTB_WEB.UserControl.SuCo.ucSuCo_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" id="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <table class="table largetable">
        <tr>
            <td style="width: 300px" class="border_right">
                <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
            </td>
            <td class="border_right">
                <h3 class="title_green fix">Danh sách sự cố</h3>
                <% if (RepeaterSuCo.Items.Count == 0)
                   { %>
                    <asp:Label ID="Label_DanhSachSuCo" runat="server" Text="Phòng chưa có sự cố"></asp:Label>
                <% }
                   else
                   { %>
                <table class="table table-bordered table-striped table-hover valign_middle">
                    <thead class="centered">
                        <tr>
                            <th>#</th>
                            <th>Tên sự cố</th>
                            <th>Tình trạng</th>
                            <th>Ngày tạo</th>
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
                                    <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ngay") %></td>
                                    <td>
                                        <button class="btn btn-default" onclick="OnMoreInfoClick('<%# Eval("urlLog") %>'); return false;"><span class="glyphicon glyphicon-tasks"></span></button>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <% } %>
                <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachSuCo" />
            </td>
            <td style="width: 400px">
                <h3 class="title_blue fix">
                    <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin sự cố"></asp:Label></h3>
                <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
                    <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
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
                </asp:Panel>
                <asp:Label ID="Label_SuCo" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl_SuCo" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="600px" Modal="True" Width="1000px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Log sự cố" Theme="PlasticBlue">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

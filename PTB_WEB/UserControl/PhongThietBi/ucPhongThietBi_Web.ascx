<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Web.ascx.cs" Inherits="PTB_WEB.UserControl.PhongThietBi.ucPhongThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/PhongThietBi/ucPhongThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhongThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>


<uc:ucPhongThietBi_BreadCrumb runat="server" ID="ucPhongThietBi_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" id="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <script type="text/javascript">
        function OnMoreInfoClick(contentUrl) {
            clientPopupControl.SetContentUrl(contentUrl);
            clientPopupControl.Show();
        }
    </script>
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 300px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td class="border_right">
                    <h3 class="title_green fix">Danh sách thiết bị </h3>
                    <% if (RepeaterDanhSachThietBi.Items.Count == 0)
                       { %>
                    <div class="panel-body">
                        <asp:Label ID="Label_DanhSachThietBi" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <table class="table table-bordered table-striped table-hover valign_middle">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Tên</th>
                                <th>Tình trạng</th>
                                <th>Số lượng</th>
                                <th>Log</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterDanhSachThietBi" runat="server">
                                <ItemTemplate>
                                    <tr <%# Eval("id").ToString() == idThietBi.ToString()?" class=\"focusrow\"":"" %>>
                                        <td class="tdcenter" onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("ten") %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("tinhtrang") %></td>
                                        <td onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer"><%# Eval("soluong") %></td>
                                        <td>
                                            <button class="btn btn-default" onclick="OnMoreInfoClick('<%# Eval("urlLog") %>'); return false;"><span class="glyphicon glyphicon-tasks"></span></button>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <% } %>
                    <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
                </td>
                <td style="width: 400px">
                    <h3 class="title_blue fix">
                        <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
                    </h3>
                    <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                        <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                        <table class="table table-striped">
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
                                    <td colspan="2" class="tdcenter">
                                        <asp:Button ID="Button_XemLog" runat="server" Text="Xem log" CssClass="btn btn-default" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <asp:Label ID="Label_ThietBi" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl_ThietBi" runat="server" ClientInstanceName="clientPopupControl" CloseAction="CloseButton" Height="600px" Modal="True" Width="1000px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Log thiết bị" Theme="PlasticBlue">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

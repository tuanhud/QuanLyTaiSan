<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.LogThietBi.ucLogThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table" style="border-top: white solid 2px">
        <tbody>
            <tr>
                <td>
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
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idLog.ToString()?" class=\"focusrow\"":"" %>>
                                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachLogThietBi.CurrentPage - 1)*CollectionPagerDanhSachLogThietBi.PageSize) %></td>
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
                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachLogThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="3" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                </td>
                <td width="400px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinLog" runat="server" Text="Thông tin nhân viên"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <table class="table table-bordered">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <div class="center">
                                                <dx:ASPxImageSlider ID="ASPxImageSlider_Log" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Tên thiết bị</th>
                                        <td>
                                            <asp:Label ID="Label_TenThietBi" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Tình trạng</th>
                                        <td>
                                            <asp:Label ID="Label_TinhTrang" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Số lượng</th>
                                        <td>
                                            <asp:Label ID="Label_SoLuong" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Phòng</th>
                                        <td>
                                            <asp:Label ID="Label_Phong" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Ngày</th>
                                        <td>
                                            <asp:Label ID="Label_Ngay" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Người thực hiện</th>
                                        <td>
                                            <asp:Label ID="Label_QuanTriVien" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="width: 120px" class="warning">Ghi chú</th>
                                        <td>
                                            <asp:Label ID="Label_GhiChu" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

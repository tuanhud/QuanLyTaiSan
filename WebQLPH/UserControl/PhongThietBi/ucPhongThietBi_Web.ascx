<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhongThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.PhongThietBi.ucPhongThietBi_Web" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="false">
    <table class="table table-bordered table-striped">
        <tbody>
            <tr>
                <td width="600px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Chọn phòng
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" Theme="MetropolisBlue" KeyFieldName="id_c" ParentFieldName="id_p" Width="100%" EnableCallbacks="False" OnFocusedNodeChanged="ASPxTreeList_ViTri_FocusedNodeChanged" OnHtmlDataCellPrepared="ASPxTreeList_ViTri_HtmlDataCellPrepared">
                            <Columns>
                                <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0">
                                </dx:TreeListTextColumn>
                                <dx:TreeListTextColumn Caption="Mô tả" FieldName="mota" Name="colmota" VisibleIndex="1">
                                </dx:TreeListTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxTreeList>
                    </div>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách thiết bị
                        </div>
                        <% if (RepeaterDanhSachThietBi.Items.Count == 0)
                           { %>   
                        <div class="panel-body">
                            <asp:Label ID="Label_DanhSachThietBi" runat="server"></asp:Label>
                        </div>
                        <% } else { %>
                        <table class="table table-bordered table-striped">
                            <thead class="centered">
                                <tr>
                                    <th>#</th>
                                    <th>Mã thiết bị</th>
                                    <th>Tên</th>
                                    <th>Loại thiết bị</th>
                                    <th>Số lượng</th>
                                    <th>Kiểu quản lí</th>
                                </tr>
                            </thead>
                            <tbody class="centered">
                                <asp:Repeater ID="RepeaterDanhSachThietBi" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                                            <td><%# Eval("subId") %></td>
                                            <td><%# Eval("ten") %></td>
                                            <td><%# Eval("tenloai") %></td>
                                            <td><%# Eval("soluong") %></td>
                                            <td><%# Eval("kieuQL") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <% } %>
                    </div>
                    <div class="leftCollectionPager">
                        <div class="CollectionPager">
                            <cp:CollectionPager ID="CollectionPagerDanhSachThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="1" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Danh sách thiết bị
                        </div>
                        <dx:ASPxGridView ID="ASPxGridView_DanhSachThietBi" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Mã thiết bị" FieldName="subId" Name="colsubid" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên thiết bị" FieldName="ten" Name="colten" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption=" Tên loại" FieldName="tenloai" Name="coltenloai" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Số lượng" FieldName="soluong" Name="colsoluong" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Kiểu quản lí" FieldName="kieuQL" Name="colkieuquanli" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager Visible="False">
                            </SettingsPager>
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxGridView>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
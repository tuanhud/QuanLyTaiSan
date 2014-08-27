<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSuCo_Web.ascx.cs" Inherits="WebQLPH.UserControl.SuCo.ucSuCo_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/SuCo/ucSuCo_BreadCrumb.ascx" TagPrefix="uc" TagName="ucSuCo_BreadCrumb" %>


<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucSuCo_BreadCrumb runat="server" ID="ucSuCo_BreadCrumb" />
    <table class="table" style="border-top: white solid 2px">
        <tr>
            <td style="width: 200px">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Vị trí
                    </div>
                    <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" KeyFieldName="id_c" ParentFieldName="id_p" AutoGenerateColumns="False" Theme="Aqua" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback" OnFocusedNodeChanged="ASPxTreeList_ViTri_FocusedNodeChanged" OnHtmlDataCellPrepared="ASPxTreeList_ViTri_HtmlDataCellPrepared">
                        <Columns>
                            <dx:TreeListTextColumn Caption="(Cơ sở, dãy, tầng)" FieldName="ten" Name="colten" VisibleIndex="0" ShowInCustomizationForm="True">
                            </dx:TreeListTextColumn>
                        </Columns>
                        <Settings ShowTreeLines="true" ShowColumnHeaders="false" SuppressOuterGridLines="true" />
                        <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
                        <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
                        <ClientSideEvents
                            CustomDataCallback="function(s, e) {
                                if(e.result != '')
                                    document.location = e.result;
                                }"
                            FocusedNodeChanged="function(s, e) { 
                                var key = treeList.GetFocusedNodeKey();
                                treeList.PerformCustomDataCallback(key); 
                            }" />
                    </dx:ASPxTreeList>
                </div>
            </td>
            <td>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Danh sách sự cố
                    </div>
                    <% if (RepeaterSuCo.Items.Count == 0)
                       { %>
                    <div class="panel-body">Chưa có sự cố</div>
                    <% }
                       else
                       { %>
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="centered">
                            <tr>
                                <th>#</th>
                                <th>Tên sự cố</th>
                                <th>Tình trạng</th>
                                <th>Mô tả</th>
                                <th>Ngày</th>
                            </tr>
                        </thead>
                        <tbody class="centered">
                            <asp:Repeater ID="RepeaterSuCo" runat="server">
                                <ItemTemplate>
                                    <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idSuCo.ToString()?" class=\"focusrow\"":"" %>>
                                        <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachSuCo.CurrentPage - 1)*CollectionPagerDanhSachSuCo.PageSize) %></td>
                                        <td><%# Eval("ten") %></td>
                                        <td><%# Eval("tinhtrang") %></td>
                                        <td><%# Eval("mota") %></td>
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
                        <cp:CollectionPager ID="CollectionPagerDanhSachSuCo" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
                    </div>
                </div>
            </td>
            <td style="width: 350px">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <asp:Label ID="Label_ThongTinSuCo" runat="server" Text="Thông tin thiết bị"></asp:Label>
                    </div>

                    <div class="panel-body">
                        <asp:Label ID="Label_ThongBao" runat="server" Text=""></asp:Label>
                        <asp:Panel ID="PanelThongBao_SuCo" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao_SuCo" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Panel_SuCo" runat="server" Visible="False">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="2">
                                        <div class="center">
                                            <dx:ASPxImageSlider ID="ASPxImageSlider_SuCo" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 120px" class="warning">Tên sự cố</th>
                                    <td>
                                        <asp:Label ID="Label_TenSuCo" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th class="warning">Tình trạng</th>
                                    <td>
                                        <asp:Label ID="Label_TinhTrang" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th class="warning">Ngày tạo</th>
                                    <td>
                                        <asp:Label ID="Label_NgayTao" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th class="warning">Mô tả</th>
                                    <td>
                                        <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Label ID="Label_SuCo" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.ThietBi.ucThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucThietBi_BreadCrumb" %>


<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
    <asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Thiết bị
            </div>
            <dx:ASPxTreeList ID="ASPxTreeList_ThietBi" runat="server" KeyFieldName="ID" AutoGenerateColumns="False" Theme="Aqua" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ThietBi_CustomDataCallback" OnFocusedNodeChanged="ASPxTreeList_ThietBi_FocusedNodeChanged">
                <Columns>
                    <dx:TreeListTextColumn Caption="ID" FieldName="id" Name="colid" VisibleIndex="0" ShowInCustomizationForm="True" Visible="false"></dx:TreeListTextColumn>
                    <dx:TreeListTextColumn Caption="(Thiết bị)" FieldName="name" Name="colname" VisibleIndex="1" ShowInCustomizationForm="True">
                    </dx:TreeListTextColumn>
                </Columns>
                <Settings ShowTreeLines="true" SuppressOuterGridLines="true" ShowColumnHeaders="false" />
                <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
                <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
                <ClientSideEvents CustomDataCallback="function(s, e) { document.location = e.result; }"
                    FocusedNodeChanged="function(s, e) { 
                                var key = treeList.GetFocusedNodeKey();
                                treeList.PerformCustomDataCallback(key); 
                            }" />
            </dx:ASPxTreeList>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Danh sách thiết bị
            </div>
            <% if (RepeaterThietBi.Items.Count == 0)
               { %>
            <div class="panel-body">Chưa có thiết bị</div>
            <% }
               else
               { %>
            <table class="table table-bordered table-striped table-hover">
                <thead class="centered">
                    <tr>
                        <th>#</th>
                        <th>Mã thiết bị</th>
                        <th>Tên thiết bị</th>
                    </tr>
                </thead>
                <tbody class="centered">
                    <asp:Repeater ID="RepeaterThietBi" runat="server">
                        <ItemTemplate>
                            <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idThietBi.ToString()?" class=\"focusrow\"":"" %>>
                                <td><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                                <td><%# Eval("subid") %></td>
                                <td><%# Eval("ten") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <% } %>
        </div>

        <div class="leftCollectionPager">
            <div class="CollectionPager">
                <cp:CollectionPager ID="CollectionPagerDanhSachThietBi" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Page" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static" SectionPadding="2"></cp:CollectionPager>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
            </div>

            <div class="panel-body">
                <asp:Panel ID="PanelThongBao_ThietBi" runat="server" Visible="False">
                    <div>
                        <div class="alert alert-danger" role="alert">
                            <span class="glyphicon glyphicon-exclamation-sign"></span>
                            <asp:Label ID="LabelThongBao_ThietBi" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                    <table class="table table-bordered">
                        <tr>
                            <td colspan="2">
                                <div class="center200">
                                    <dx:ASPxImageSlider ID="ASPxImageSlider_ThietBi" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="200px">
                                        <Styles>
                                            <ImageArea BackColor="White"></ImageArea>
                                        </Styles>
                                    </dx:ASPxImageSlider>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th style="width: 120px" class="warning">Mã thiết bị</th>
                            <td>
                                <asp:Label ID="Label_MaThietBi" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <th class="warning">Tên thiết bị</th>
                            <td>
                                <asp:Label ID="Label_TenThietBi" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <th class="warning">Loại thiết bị</th>
                            <td>
                                <asp:Label ID="Label_LoaiThietBi" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <th class="warning">Ngày mua</th>
                            <td>
                                <asp:Label ID="Label_NgayMua" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <th class="warning">Mô tả</th>
                            <td>
                                <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="Label_ThietBi" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
        <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
    </asp:Panel>
</asp:Panel>

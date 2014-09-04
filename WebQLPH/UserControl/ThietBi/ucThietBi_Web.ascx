<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.ThietBi.ucThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
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
    <script type="text/javascript">
        var clickCount = 0;
        function Show(url_img) {
            clickCount++;
            setTimeout(function () { clickCount = 0; }, 300);
            if (clickCount == 2) {
                PopupControlImage.SetContentUrl(url_img);
                PopupControlImage.Show();
                clickCount = 0;
            }
        }
    </script>
    <table class="table">
        <thead>
            <tr>
                <td colspan="3">
                    <uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
                </td>
            </tr>
        </thead>
        <tbody style="border-top: white solid 2px">
            <tr>
                <td style="width: 200px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Thiết bị
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ThietBi" runat="server" KeyFieldName="ID" AutoGenerateColumns="False" Theme="Aqua" ClientInstanceName="treeList" Width="100%" OnCustomDataCallback="ASPxTreeList_ThietBi_CustomDataCallback">
                            <Columns>
                                <dx:TreeListTextColumn Caption="ID" FieldName="id" Name="colid" VisibleIndex="0" Visible="false"></dx:TreeListTextColumn>
                                <dx:TreeListTextColumn Caption="(Thiết bị)" FieldName="name" Name="colname" VisibleIndex="1">
                                </dx:TreeListTextColumn>
                            </Columns>
                            <Settings ShowColumnHeaders="False" />
                            <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
                            <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
                            <ClientSideEvents CustomDataCallback="function(s, e) { document.location = e.result; }"
                                NodeClick="function(s, e) {
	                                var key = e.nodeKey;
	                                treeList.PerformCustomDataCallback(key);
                                }" />
                        </dx:ASPxTreeList>
                    </div>
                </td>
                <td>
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
                                    <th>Loại thiết bị</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterThietBi" runat="server">
                                    <ItemTemplate>
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idThietBi.ToString()?" class=\"focusrow\"":"" %>>
                                            <td class="tdcenter"><%# Container.ItemIndex + 1 + ((CollectionPagerDanhSachThietBi.CurrentPage - 1)*CollectionPagerDanhSachThietBi.PageSize) %></td>
                                            <td><%# Eval("subid") %></td>
                                            <td><%# Eval("ten") %></td>
                                            <td><%# Eval("loaithietbi") %></td>
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
                </td>

                <td style="width: 400px">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
                        </div>

                        <div class="panel-body">
                            <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                                <div class="image_center" onclick="Show('<% Response.Write(Session["URL"]); %>');">
                                    <dx:ASPxImageSlider ID="ASPxImageSlider_ThietBi" runat="server" BinaryImageCacheFolder="~\Thumb\" ShowNavigationBar="False" Width="350px" Height="300px" SettingsImageArea-ImageSizeMode="FillAndCrop">
                                        <Styles>
                                            <PassePartout BackColor="Transparent" />
                                        </Styles>
                                    </dx:ASPxImageSlider>
                                </div>
                                <table class="table table-striped">
                                    <tbody>
                                        <tr>
                                            <td style="width:100px;">Mã thiết bị:</td>
                                            <td>
                                                <asp:Label ID="Label_MaThietBi" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Tên thiết bị:</td>
                                            <td>
                                                <asp:Label ID="Label_TenThietBi" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Loại thiết bị:</td>
                                            <td>
                                                <asp:Label ID="Label_LoaiThietBi" runat="server" Text="Label"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Ngày mua:</td>
                                            <td>
                                                <asp:Label ID="Label_NgayMua" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Mô tả:</td>
                                            <td>
                                                <asp:Label ID="Label_MoTa" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="Label_ThietBi" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <dx:ASPxPopupControl ID="ASPxPopupControl" runat="server" ClientInstanceName="PopupControlImage" CloseAction="CloseButton" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Hình ảnh" Theme="PlasticBlue" AllowResize="True" AutoUpdatePosition="True" Width="800px" Height="600px">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Panel>

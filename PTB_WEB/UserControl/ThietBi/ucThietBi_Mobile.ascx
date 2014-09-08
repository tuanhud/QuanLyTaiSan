<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.ThietBi.ucThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucThietBi_BreadCrumb" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
    <asp:Panel ID="Panel_TreeList" runat="server" Visible="False">
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
        <div class="panel panel-primary">
            <div class="panel-heading">
                Danh sách thiết bị
            </div>
            <% if (RepeaterThietBi.Items.Count == 0)
               { %>
            <div class="panel-body"><asp:Label ID="Label_TextDanhSachThietBi" runat="server"></asp:Label></div>
            <% }
               else
               { %>
            <table class="table table-bordered table-striped table-hover valign_middle">
                <thead class="centered">
                    <tr>
                        <th>#</th>
                        <th>Mã thiết bị</th>
                        <th>Tên thiết bị</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterThietBi" runat="server">
                        <ItemTemplate>
                            <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                                <td><%# Eval("subid") %></td>
                                <td><%# Eval("ten") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <% } %>
        </div>
        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
    </asp:Panel>

    <asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label>
            </div>

            <div class="panel-body">
                <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
                <table class="table table-striped">
                    <tbody>
                        <tr>
                            <td style="width: 120px">Mã thiết bị:</td>
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
            </div>
        </div>
        <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
    </asp:Panel>
</asp:Panel>

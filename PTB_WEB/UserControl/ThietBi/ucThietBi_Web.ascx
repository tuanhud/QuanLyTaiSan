<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThietBi_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ThietBi.ucThietBi_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/ThietBi/ucThietBi_BreadCrumb.ascx" TagPrefix="uc" TagName="ucThietBi_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>

<uc:ucThietBi_BreadCrumb runat="server" ID="ucThietBi_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" ID="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                </td>
                <td>
                    <% if (RepeaterThietBi.Items.Count == 0)
                       { %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_TextDanhSachThietBi" runat="server"></asp:Label>
                    </div>
                    <% }
                       else
                       { %>
                    <ul class="nav nav-tabs" role="tablist" id="myTab">
                        <li class="active"><a href="#danhsach" role="tab" data-toggle="tab">Danh sách thiết bị</a></li>
                        <%if (Request.QueryString["id"] != null)
                          { %>
                        <li><a href="#thongtin" role="tab" data-toggle="tab">
                            <asp:Label ID="Label_ThongTinThietBi" runat="server" Text="Thông tin thiết bị"></asp:Label></a></li>
                        <script>
                            $(function () {
                                $('#myTab a:last').tab('show')
                            })
                        </script>
                        <%} %>
                    </ul>
                    <asp:Panel ID="PanelChangePage" runat="server" Visible="false">
                        <script>
                            $(function () {
                                $('#myTab a:first').tab('show')
                            })
                        </script>
                    </asp:Panel>
                    <div class="tab-content">
                        <div class="tab-pane active" id="danhsach">
                            <table class="table table-bordered table-striped table-hover valign_middle">
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
                                                <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachThietBi.CollectionPager_Object.PageSize) %></td>
                                                <td><%# Eval("subid") %></td>
                                                <td><%# Eval("ten") %></td>
                                                <td><%# Eval("loaithietbi") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachThietBi" />
                        </div>
                        <div class="tab-pane" id="thongtin">
                            <asp:Panel ID="Panel_ThietBi" runat="server" Visible="False">
                                <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
                                <table class="table table-striped">
                                    <tbody>
                                        <tr>
                                            <td style="width: 100px;">Mã thiết bị:</td>
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
                    <% } %>
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

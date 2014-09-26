<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Web.ascx.cs" Inherits="TSCD_WEB.UserControl.Phong.ucPhong_Web" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/CollectionPager/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/TreeViTri/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>

<uc:ucPhong_BreadCrumb runat="server" ID="ucPhong_BreadCrumb" />

<table class="table largetable">
    <tbody>
        <tr id="KhongCoDuLieu" runat="server" visible="false">
            <td>
                <uc:ucDanger runat="server" ID="ucDanger_KhongCoDuLieu" />
            </td>
        </tr>
        <tr id="infotr" runat="server" visible="false">
            <td style="width: 210px" class="border_right">
                <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
            </td>
            <td id="ChuaChonViTri" runat="server" visible="false">
                <uc:ucWarning runat="server" ID="ucWarning_ChuaChonViTri" />
            </td>
            <td id="infotd" runat="server" visible="false">
                <ul class="nav nav-tabs" role="tablist" id="myTab">
                    <li class="active"><a href="#danhsach" role="tab" data-toggle="tab">Danh sách phòng</a></li>
                    <li id="ThongTinPhong" runat="server" visible="false"><a href="#thongtin" role="tab" data-toggle="tab">
                        <asp:Label ID="Label_ThongTinPhong" runat="server" Text="Thông tin phòng"></asp:Label></a>
                        <script>
                        $(function () {
                            $('#myTab a:last').tab('show')
                        })
                        </script>
                    </li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="danhsach">
                        <table class="table table-bordered table-striped table-hover valign_middle">
                            <thead>
                                <tr>
                                    <th class="tdcenter">#</th>
                                    <th>Tên phòng</th>
                                    <th>Mô tả</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                                    <ItemTemplate>
                                        <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer" <%# Eval("id").ToString() == idPhong.ToString()?" class=\"focusrow\"":"" %>>
                                            <td class="tdcenter"><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
                                            <td><%# Eval("ten") %></td>
                                            <td><%# Eval("subid") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
                    </div>
                    <div class="tab-pane" id="thongtin" clientidmode="static" runat="server" visible="false">
                        <table class="table largetable" style="height: auto">
                            <tr>
                                <td>
                                    <table class="table table-striped">
                                        <tbody>
                                            <tr>
                                                <td style="width: 120px">Mã phòng:</td>
                                                <td>
                                                    <asp:Label ID="Label_MaPhong" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Tên phòng:</td>
                                                <td>
                                                    <asp:Label ID="Label_TenPhong" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Vị trí:</td>
                                                <td>
                                                    <asp:Label ID="Label_ViTriPhong" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Mô tả:</td>
                                                <td>
                                                    <asp:Label ID="Label_MoTaPhong" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </tbody>
</table>
<asp:Panel ID="PanelChangePage" runat="server" Visible="false">
    <script>
        $(function () {
            $('#myTab a:first').tab('show')
        })
    </script>
</asp:Panel>

﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Mobile.ascx.cs" Inherits="TSCD_WEB.UserControl.Phong.ucPhong_Mobile" %>
<%@ Register Src="~/UserControl/CollectionPager/ucCollectionPager.ascx" TagPrefix="uc" TagName="ucCollectionPager" %>
<%@ Register Src="~/UserControl/Phong/ucPhong_BreadCrumb.ascx" TagPrefix="uc" TagName="ucPhong_BreadCrumb" %>
<%@ Register Src="~/UserControl/TreeViTri/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>

<uc:ucPhong_BreadCrumb runat="server" ID="ucPhong_BreadCrumb" />

<table class="table largetable">
    <tbody>
        <tr id="KhongCoDuLieu" runat="server" visible="false">
            <td>
                <uc:ucDanger runat="server" ID="ucDanger_KhongCoDuLieu" />
            </td>
        </tr>
        <tr id="TreeViTri" runat="server" visible="false">
            <td>
                <uc:ucTreeViTri runat="server" ID="ucTreeViTri" />
            </td>
        </tr>
        <tr id="KhongCoPhong" runat="server" visible="false">
            <td>
                <uc:ucWarning runat="server" ID="ucWarning_KhongCoPhong" />
            </td>
        </tr>
        <tr id="DanhSach" runat="server" visible="false">
            <td>
                <h3 class="title_blue fix">Danh sách phòng</h3>
                <table class="table table-bordered table-striped table-hover">
                    <thead class="centered">
                        <tr>
                            <th>#</th>
                            <th>Tên phòng</th>
                            <th>Mô tả</th>
                        </tr>
                    </thead>
                    <tbody class="centered">
                        <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                            <ItemTemplate>
                                <tr onclick="location.href='<%# Eval("url") %>'" style="cursor: pointer">
                                    <td><%# Container.ItemIndex + 1 + ((_ucCollectionPager_DanhSachPhong.CollectionPager_Object.CurrentPage - 1)*_ucCollectionPager_DanhSachPhong.CollectionPager_Object.PageSize) %></td>
                                    <td><%# Eval("ten") %></td>
                                    <td><%# Eval("subid") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <uc:ucCollectionPager runat="server" ID="_ucCollectionPager_DanhSachPhong" />
            </td>
        </tr>
        <tr id="ThongTin" runat="server" visible="false">
            <td>
                <h3 class="title_green fix">Thông tin phòng</h3>
                <table class="table table-striped noboder">
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
    </tbody>
</table>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="TSCD_WEB.UserControl.ViTri.ucViTri_Web" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/TreeViTri/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>

<uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />

<table class="table largetable">
    <tbody>
        <tr id="KhongCoDuLieu" runat="server" visible="false">
            <td>
                <uc:ucDanger runat="server" ID="ucDanger_KhongCoDuLieu" />
            </td>
        </tr>
        <tr id="infotr" runat="server" visible="false">
            <td style="width: 210px" class="border_right">
                <uc:ucTreeViTri runat="server" ID="ucTreeViTri" />
            </td>
            <td id="ChuaChonViTri" runat="server" visible="false">
                <uc:ucWarning runat="server" ID="ucWarning_ChuaChonViTri" />
            </td>
            <td id="infotd" runat="server" visible="false">
                <h3 class="title_green fix">
                    <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                </h3>
                <table class="table table-striped">
                    <tbody>
                        <tr>
                            <td>Tên:</td>
                            <td>
                                <asp:Label ID="Label_Ten" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Thuộc:</td>
                            <td>
                                <asp:Label ID="Label_Thuoc" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Mô tả:</td>
                            <td>
                                <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>

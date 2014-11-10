<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="TSCD_WEB.DangNhap" %>

<%@ Register Src="~/UserControl/DangNhap/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>
<%@ Register Src="~/UserControl/Footer/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Đăng Nhập :: Tài sản cố định :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="DangNhap.aspx">Đăng nhập</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <div class="center">
                        <uc:ucDangNhap runat="server" ID="ucDangNhap" />
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

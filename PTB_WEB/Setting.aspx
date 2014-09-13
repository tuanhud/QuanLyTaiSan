<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="PTB_WEB.Setting" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>
<%@ Register Src="~/UserControl/Alert/ucInfo.ascx" TagPrefix="uc" TagName="ucInfo" %>
<%@ Register Src="~/UserControl/Alert/ucSuccess.ascx" TagPrefix="uc" TagName="ucSuccess" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Cài đặt hệ thống :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="Setting.aspx">Cài đặt</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr runat="server" visible="false" id="DangNhap">
                <td>
                    <div class="center">
                        <uc:ucDangNhap runat="server" ID="ucDangNhap"/>
                    </div>
                </td>
            </tr>
            <uc:ucWarning runat="server" ID="_ucWarning" Visible="false" />
            <asp:Panel ID="PanelThongTin" runat="server" Visible="false">
                <tr>
                    <td colspan="2">
                        <h3 class="title_green fix">Cấu hình mẫu gửi mail</h3>
                        <uc:ucDanger runat="server" ID="ucDanger" Visible="false" />
                        <uc:ucInfo runat="server" ID="ucInfo" Visible="false" />
                        <uc:ucSuccess runat="server" ID="ucSuccess" Visible="false" />
                        <uc:ucWarning runat="server" ID="ucWarning" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 210px" class="border_right">
                        <h3 class="title_orange fix">Biến dữ liệu</h3>
                        <%--<ul>
                        <li><a href="#">{HoTenNguoiDuyet}</a></li>
                        <li>{EmailNguoiDuyet}</li>
                        <li>{HoTenNguoiNhan}</li>
                        <li>{EmailNguoiNhan}</li>
                        <li>{TinhTrang}</li>
                        <li>{GhiChu}</li>
                    </ul>--%>

                        <p class="bg-success draggable">{HoTenNguoiDuyet}</p>
                        <p class="bg-success draggable">{EmailNguoiDuyet}</p>
                        <p class="bg-success draggable">{HoTenNguoiNhan}</p>
                        <p class="bg-success draggable">{EmailNguoiNhan}</p>
                        <p class="bg-success draggable">{ThongTinPhieuMuon}</p>
                        <p class="bg-success draggable">{TinhTrang}</p>
                        <p class="bg-success draggable">{GhiChu}</p>
                    </td>
                    <td>
                        <h3 class="title_blue fix">Mẫu gửi mail</h3>
                        <asp:TextBox CssClass="form-control" ID="TextBoxMailTemplate" ClientIDMode="Static" runat="server" TextMode="MultiLine"></asp:TextBox><br />
                        <script>
                            CKEDITOR.replace('TextBoxMailTemplate');
                        </script>
                        <asp:Button ID="ButtonSaveMailTemplate" runat="server" Text="Lưu cấu hình" CssClass="btn btn-success" OnClick="ButtonSaveMailTemplate_Click" />
                    </td>
                </tr>
            </asp:Panel>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

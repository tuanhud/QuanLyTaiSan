<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="PTB_WEB.Setting" ValidateRequest="false" %>

<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>
<%@ Register Src="~/UserControl/Alert/ucInfo.ascx" TagPrefix="uc" TagName="ucInfo" %>
<%@ Register Src="~/UserControl/Alert/ucSuccess.ascx" TagPrefix="uc" TagName="ucSuccess" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Cài đặt hệ thống :: Quản lý Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#TextBoxMailTieuDe').click(function () {
                _TextBoxMailTieuDe_Focus = 1;
            });

            CKEDITOR.instances['TextBoxMailNoiDung'].on('contentDom', function () {
                this.document.on('click', function (event) {
                    _TextBoxMailTieuDe_Focus = 0;
                });
            });
        });
    </script>
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="Setting.aspx">Cài đặt</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr runat="server" visible="false" id="DangNhap">
                <td>
                    <div class="center">
                        <uc:ucDangNhap runat="server" ID="ucDangNhap" />
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
                        <i>Đặt con trỏ vào vị trí cần chèn sau đó click vào biến dữ liệu</i>
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{HoTenNguoiDuyet}')">{HoTenNguoiDuyet}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{EmailNguoiDuyet}')">{EmailNguoiDuyet}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{HoTenNguoiNhan}')">{HoTenNguoiNhan}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{EmailNguoiNhan}')">{EmailNguoiNhan}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{NgayTao}')">{NgayTao}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{ThongTinPhieuMuon}')">{ThongTinPhieuMuon}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{TinhTrang}')">{TinhTrang}</label><br />
                        <label class="alert-success" style="cursor: pointer" onclick="insertIntoCkeditor('{GhiChu}')">{GhiChu}</label><br />
                    </td>
                    <td>
                        <h3 class="title_blue fix">Mẫu gửi mail</h3>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Tiêu đề</label>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxMailTieuDe" ClientIDMode="Static" runat="server" onfocus="TextBoxMailTieuDe_Focus();"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Nội dung</label>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxMailNoiDung" ClientIDMode="Static" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <script>
                                        CKEDITOR.replace('TextBoxMailNoiDung');
                                    </script>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-2 control-label">
                                    <asp:Button ID="ButtonSaveMailTemplate" runat="server" Text="Lưu cấu hình" CssClass="btn btn-success" OnClick="ButtonSaveMailTemplate_Click" />
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </asp:Panel>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

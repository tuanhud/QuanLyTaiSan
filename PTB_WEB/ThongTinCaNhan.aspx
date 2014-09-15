<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="PTB_WEB.ThongTinCaNhan" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Thông tin cá nhân :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="ThongTinCaNhan.aspx">Thông tin cá nhân</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <asp:Panel ID="PanelDangNhap" runat="server" Visible="False">
                        <div class="center">
                            <uc:ucDangNhap runat="server" ID="ucDangNhap" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelThongBaoThanhCong" runat="server" Visible="False">
                        <div class="alert alert-success" role="alert">
                            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>

                            <span class="glyphicon glyphicon-ok-circle"></span>
                            <asp:Label ID="LabelThongBaoThanhCong" runat="server" Text="Label"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelThongBaoThatBai" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">
                                <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>

                                <span class="glyphicon glyphicon-remove-circle"></span>
                                <asp:Label ID="LabelThongBaoThatBai" runat="server" Text="Label"></asp:Label>
                            </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelEditThongTinCaNhan" runat="server" Visible="False" ClientIDMode="Static">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title"><span class="glyphicon glyphicon glyphicon-pencil"></span>&nbsp;Chỉnh sửa thông tin cá nhân <b>
                                    <asp:Label ID="LabelHoTen" runat="server" Text="Nguyễn Hoàng Thanh"></asp:Label></b></h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Họ Tên:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxHoTen" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Email:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Nhóm:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:DropDownList ID="DropDownListNhom" runat="server" DataValueField="id" DataTextField="ten" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Tài khoản:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxTaiKhoan" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Mật khẩu mới:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxMatKhauMoi" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                            <i id="thongbaomatkhau" style="font-size: small; color: blue">Để trống nếu không muốn thay đổi</i>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Khoa (Phòng Ban):
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxDonVi" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Ghi chú:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextBoxGhiChu" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-8">
                                            <asp:Button ID="ButtonLuuThongTinCaNhan" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="ButtonLuuThongTinCaNhan_Click" />
                                            <asp:Button ID="ButtonHuy" runat="server" Text="Hủy" CssClass="btn btn-default" OnClick="ButtonHuy_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelThongTinCaNhan" runat="server" Visible="False" ClientIDMode="Static">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title"><span class="glyphicon glyphicon glyphicon-user"></span>&nbsp;Thông tin cá nhân
                                    <asp:LinkButton ID="LinkButtonEditThongTinCaNhan" runat="server" OnClick="LinkButtonEditThongTinCaNhan_Click"><span class="glyphicon glyphicon glyphicon-pencil right"></span></asp:LinkButton>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Họ Tên:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelHoTens" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Email:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelEmail" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Nhóm:
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:HiddenField ID="HiddenFieldIDNhom" runat="server" />
                                            <b>
                                                <asp:Label ID="LabelNhom" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Tài khoản:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelTaiKhoan" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Khoa (Phòng Ban):
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelKhoa" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Ngày tạo:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelNgayTao" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Ngày chỉnh sửa:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelNgayChinhSua" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Ghi chú:
                                        </div>
                                        <div class="col-lg-8">
                                            <b>
                                                <asp:Label ID="LabelGhiChu" runat="server" Text="Label"></asp:Label></b>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

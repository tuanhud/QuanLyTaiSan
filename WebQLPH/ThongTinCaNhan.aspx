<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs" Inherits="WebQLPH.ThongTinCaNhan" %>

<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc1" TagName="ucDangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thông tin cá nhân</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelDangNhap" runat="server" Visible="false">
        <div class="center">
            <uc1:ucDangNhap runat="server" ID="ucDangNhap" />
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelEditThongTinCaNhan" runat="server" Visible="False" ClientIDMode="Static">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><span class="glyphicon glyphicon glyphicon-pencil"></span>&nbsp;Chỉnh sửa thông tin cá nhân <b><asp:Label ID="LabelHoTen" runat="server" Text="Nguyễn Hoàng Thanh"></asp:Label></b></h3>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
                        <div class="row">
                            <div class="alert alert-danger" role="alert">
                                <span class="glyphicon glyphicon-exclamation-sign"></span>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
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
                            <b>thanh@gmail.com</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Tài khoản:
                        </div>
                        <div class="col-lg-8">
                            <b>thanh</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Khoa (Phòng Ban):
                        </div>
                        <div class="col-lg-8">
                            <b>Công Nghệ Thông Tin</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ngày tạo:
                        </div>
                        <div class="col-lg-8">
                            <b>18/08/2014 15h29</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ngày chỉnh sửa:
                        </div>
                        <div class="col-lg-8">
                            <b>18/08/2014 15h29</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ghi chú:
                        </div>
                        <div class="col-lg-8">
                            <b>KHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông có</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Được tạo bởi:
                        </div>
                        <div class="col-lg-8">
                            <b>admin</b>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelThongTinCaNhan" runat="server" Visible="true" ClientIDMode="Static">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panel-title"><span class="glyphicon glyphicon glyphicon-user"></span>&nbsp;Thông tin cá nhân <asp:LinkButton ID="LinkButtonEditThongTinCaNhan" runat="server" OnClick="LinkButtonEditThongTinCaNhan_Click"><span class="glyphicon glyphicon glyphicon-pencil right"></span></asp:LinkButton></h3>
            </div>
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-4">
                            Họ Tên:
                        </div>
                        <div class="col-lg-8">
                            <b>Nguyễn Hoàng Thanh</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Email:
                        </div>
                        <div class="col-lg-8">
                            <b>thanh@gmail.com</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Tài khoản:
                        </div>
                        <div class="col-lg-8">
                            <b>thanh</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Khoa (Phòng Ban):
                        </div>
                        <div class="col-lg-8">
                            <b>Công Nghệ Thông Tin</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ngày tạo:
                        </div>
                        <div class="col-lg-8">
                            <b>18/08/2014 15h29</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ngày chỉnh sửa:
                        </div>
                        <div class="col-lg-8">
                            <b>18/08/2014 15h29</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Ghi chú:
                        </div>
                        <div class="col-lg-8">
                            <b>KHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông cóKHông có</b>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            Được tạo bởi:
                        </div>
                        <div class="col-lg-8">
                            <b>admin</b>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

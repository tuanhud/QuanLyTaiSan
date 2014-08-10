<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDangNhap.ascx.cs" Inherits="WebQLPH.UserControl.ucDangNhap" %>
<div class="panel panel-success">
    <div class="panel-heading">
        <h3 class="panel-title">Đăng nhập</h3>
    </div>
    <div class="panel-body">
        <div class="col-lg-12">
            <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
                <div class="row">
                    <div class="alert alert-danger" role="alert">
                        <span class="glyphicon glyphicon-exclamation-sign"></span>
                        <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">
                <asp:TextBox ID="TextBoxTaiKhoan" runat="server" CssClass="form-control" placeholder="Tài khoản" Text="admin"></asp:TextBox>
            </div>
            <br />
            <div class="row">
                <asp:TextBox ID="TextBoxMatKhau" runat="server" CssClass="form-control" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <div class="row">
                <asp:CheckBox ID="CheckBoxQuanTriVien" runat="server" Checked="true" />
                Tôi là quản trị viên
            </div>
            <div class="row">
                <asp:CheckBox ID="CheckBoxNhoDangNhap" runat="server" />
                Nhớ đăng nhập lần sau
            </div>
            <br />
            <asp:Button ID="ButtonDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-success center-block" OnClick="ButtonDangNhap_Click" />
        </div>
    </div>
</div>

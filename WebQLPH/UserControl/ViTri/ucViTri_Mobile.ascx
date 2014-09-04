<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.ViTri.ucViTri_Mobile" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
    <div class="panel panel-primary">
        <div class="panel-heading">
            Vị trí
        </div>
        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
    </div>
</asp:Panel>

<asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
        </div>

        <div class="panel-body">
            <table class="table table-bordered">
                <tbody>
                    <tr>
                        <td colspan="2">
                            <div class="center200">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"><Styles><PassePartout BackColor="Transparent" /></Styles></dx:ASPxImageSlider>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Tên</th>
                        <td>
                            <asp:Label ID="Label_Ten" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 120px" class="warning">Thuộc</th>
                        <td>
                            <asp:Label ID="Label_Thuoc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="Panel_DiaChi" runat="server" Visible="False">
                        <tr>
                            <th style="width: 120px" class="warning">Đia chỉ</th>
                            <td>
                                <asp:Label ID="Label_DiaChi" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th style="width: 120px" class="warning">Mô tả</th>
                        <td>
                            <asp:Label ID="Label_MoTa" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:Button ID="Button_Map" CssClass="btn btn-success" runat="server" Text="Xem bản đồ" OnClick="Button_Map_Click" Width="100px" />
    <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
</asp:Panel>

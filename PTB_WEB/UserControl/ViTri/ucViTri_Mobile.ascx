<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Mobile.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_Mobile" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Mobile.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Mobile" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />
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
                <uc:ucASPxImageSlider_Mobile runat="server" ID="_ucASPxImageSlider_Mobile" />
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
                        <asp:Panel ID="Panel_DiaChi" runat="server" Visible="False">
                            <tr>
                                <td>Đia chỉ:</td>
                                <td>
                                    <asp:Label ID="Label_DiaChi" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td>Mô tả:</td>
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
</asp:Panel>

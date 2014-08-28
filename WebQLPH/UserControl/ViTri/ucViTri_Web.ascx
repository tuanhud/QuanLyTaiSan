<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="WebQLPH.UserControl.ViTri.ucViTri_Web" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table table-bordered table-striped">
        <tbody>
            <tr>
                <td width="300">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Vị trí
                        </div>
                        <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    </div>
                    <asp:Panel ID="Panel_GoogleMap" runat="server" Visible="False">
                        <div class="panel panel-primary" data-toggle="modal" data-target="#myModal" onclick="return false;">
                            <div class="panel-heading">
                                Bản đồ
                            </div>
                            <iframe id="Iframe_GoogleMap" width="100%" height="300px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
                        </div>
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                        <h4 class="modal-title" id="myModalLabel">Bản đồ</h4>
                                    </div>
                                    <div class="modal-body">
                                        <iframe id="Iframe_Popup" width="100%" height="500px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="Label_Script" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                        </div>

                        <div class="panel-body">
                            <table class="table table-bordered">
                                <tr>
                                    <td colspan="2">
                                        <div class="center">
                                            <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
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
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
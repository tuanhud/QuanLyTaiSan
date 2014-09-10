<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="PTB_WEB.UserControl.ViTri.ucViTri_Web" %>

<%@ Register Src="~/UserControl/ucASPxImageSlider_Web.ascx" TagPrefix="uc" TagName="ucASPxImageSlider_Web" %>
<%@ Register Src="~/UserControl/ucTreeViTri.ascx" TagPrefix="uc" TagName="ucTreeViTri" %>
<%@ Register Src="~/UserControl/ViTri/ucViTri_BreadCrumb.ascx" TagPrefix="uc" TagName="ucViTri_BreadCrumb" %>
<%@ Register Src="~/UserControl/ucThongBaoLoi.ascx" TagPrefix="uc" TagName="ucThongBaoLoi" %>


<uc:ucViTri_BreadCrumb runat="server" ID="ucViTri_BreadCrumb" />
<uc:ucThongBaoLoi runat="server" id="ucThongBaoLoi" />

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <table class="table largetable">
        <tbody>
            <tr>
                <td style="width: 210px" class="border_right">
                    <uc:ucTreeViTri runat="server" ID="_ucTreeViTri" />
                    <asp:Panel ID="Panel_GoogleMap" runat="server" Visible="False">
                        <h3 class="title_blue">Bản đồ<span class="glyphicon glyphicon-new-window pull-right" style="cursor: pointer" data-toggle="modal" data-target="#myModal" onclick="return false;"></span></h3>
                        <iframe id="Iframe_GoogleMap" width="100%" height="300px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
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
                    <%if(Request.QueryString["key"] == null){ %>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <asp:Label ID="Label_ChuaChon" runat="server" Visible="false"></asp:Label>
                    </div>
                    <%}else{ %>
                    <h3 class="title_green fix">
                        <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label></h3>
                    <asp:Panel ID="Panel_ThongTinViTri" runat="server" Visible="False">
                        <uc:ucASPxImageSlider_Web runat="server" ID="_ucASPxImageSlider_Web" />
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
                    </asp:Panel>
                    <%} %>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

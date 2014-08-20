<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Web.ascx.cs" Inherits="WebQLPH.UserControl.ViTri.ucViTri_Web" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxImageSlider" tagprefix="dx" %>

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
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id_c" ParentFieldName="id_p" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" EnableTheming="True" EnableCallbacks="False" OnFocusedNodeChanged="ASPxTreeList_ViTri_FocusedNodeChanged"><Columns><dx:TreeListTextColumn Caption="(Cơ sở, dãy, tầng)" FieldName="ten" Name="colten" VisibleIndex="0"></dx:TreeListTextColumn></Columns><SettingsBehavior AllowFocusedNode="True" ProcessFocusedNodeChangedOnServer="True" /><SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" /></dx:ASPxTreeList>
                    </div>
                    <asp:Panel ID="Panel_GoogleMap" runat="server" Visible="False">
                        <div class="panel panel-primary" data-toggle="modal" data-target="#myModal" onclick="return false;">
                            <div class="panel-heading">
                                Bản đồ
                            </div>
                            <iframe id="Iframe_GoogleMap" runat="server" width="100%" height="300px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
                        </div>
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                        <h4 class="modal-title" id="myModalLabel">Bản đồ</h4>
                                    </div>
                                    <div class="modal-body">
                                        <iframe ID="Iframe_Popup" runat="server" width="100%" height="500px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=""></iframe>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                        </div>

                        <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
        
                        <div class="panel-body">
                            <div class="center">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-2">Tên</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Ten" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Thuộc</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Thuoc" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <asp:Panel ID="Panel_DiaChi" runat="server" Visible="False">
                                    <div class="row">
                                        <div class="col-lg-2">Địa chỉ</div>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="TextBox_DiaChi" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                </asp:Panel>
                                <div class="row">
                                    <div class="col-lg-2">Mô tả</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Mota" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
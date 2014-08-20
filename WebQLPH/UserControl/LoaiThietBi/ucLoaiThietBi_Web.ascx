<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiThietBi_Web.ascx.cs" Inherits="WebQLPH.UserControl.LoaiThietBis.ucLoaiThietBi_Web" %>

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
                           Loại thiết bị
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_LoaiThietBi" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ParentFieldName="parent_id" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" EnableTheming="True" EnableCallbacks="False" OnFocusedNodeChanged="ASPxTreeList_LoaiThietBi_FocusedNodeChanged"><Columns><dx:TreeListTextColumn Caption="(Loại thiết bị)" FieldName="ten" Name="colten" VisibleIndex="0"></dx:TreeListTextColumn></Columns><SettingsBehavior AllowFocusedNode="True" ProcessFocusedNodeChangedOnServer="True" /><SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" /></dx:ASPxTreeList>
                    </div>
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
                            <div>
                                <div class="row">
                                    <div class="col-lg-2">Tên loại</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Ten" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Kiểu quản lý</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_KieuQuanLy" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Mô tả</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Mota" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Thuộc</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_Thuoc" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
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
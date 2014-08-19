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
                <td width="250">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Vị trí
                        </div>
                        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id_c" ParentFieldName="id_p" Theme="Aqua" OnFocusedNodeChanged="ASPxTreeList_ViTri_FocusedNodeChanged">
                            <Columns>
                                <dx:TreeListTextColumn Caption="(Cơ sở, dãy, tầng)" FieldName="ten" Name="colten" VisibleIndex="0">
                                </dx:TreeListTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedNode="True" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        </dx:ASPxTreeList>
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
                            <div class="center">
                                <dx:ASPxImageSlider ID="ASPxImageSlider1" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px">
                                </dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="Tên"></asp:Label>
                                <asp:TextBox ID="TextBox_MaNhanVien" CssClass="form-control" placeholder="Tên" runat="server" Enabled="False"></asp:TextBox>
                                <br />

                                <asp:Label ID="Label2" runat="server" Text="Thuộc"></asp:Label>
                                <asp:TextBox ID="TextBox_HoTen" CssClass="form-control" placeholder="Thuộc" runat="server" Enabled="False"></asp:TextBox>
                                <br />

                                <asp:Label ID="Label_DiaChi" runat="server" Text="Địa chỉ"></asp:Label>
                                <asp:TextBox ID="TextBox_SoDienThoai" CssClass="form-control" placeholder="Địa chỉ" runat="server" Enabled="False"></asp:TextBox>
                                <br />

                                <asp:Label ID="Label4" runat="server" Text="Mô tả"></asp:Label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Mô tả" runat="server" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
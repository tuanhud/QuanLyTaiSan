<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhong_Web.ascx.cs" Inherits="WebQLPH.UserControl.Phong.ucPhong_Web" %>

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
                </td>
                <td>
                    Danh sách phòng
                </td>
                <td>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
                        </div>

                        <asp:Panel ID="PanelThongBao_Phong" runat="server" Visible="False">
                            <div>
                                <div class="alert alert-danger" role="alert">
                                    <span class="glyphicon glyphicon-exclamation-sign"></span>
                                    <asp:Label ID="LabelThongBao_Phong" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
        
                        <div class="panel-body">
                            <div class="center">
                                <dx:ASPxImageSlider ID="ASPxImageSlider_Phong" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="300px" ShowNavigationBar="False" Width="300px"></dx:ASPxImageSlider>
                            </div>
                            <br />
                            <div>
                                <div class="row">
                                    <div class="col-lg-2">Mã phòng</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_MaPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">Tên phòng</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_TenPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Vị trí</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_ViTriPhong" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2">Mô tả</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_MoTaPhong" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-2">Nhân viên phụ trách</div>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="TextBox_NhanVienPhuTrach" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
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
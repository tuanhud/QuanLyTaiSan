<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiThietBi_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.LoaiThietBis.ucLoaiThietBi_Mobile" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxImageSlider" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="Panel_Chinh" runat="server" Visible="False">
    <asp:Panel ID="Panel_TreeViTri" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Loại thiết bị
            </div>
            <dx:ASPxTreeList ID="ASPxTreeList_LoaiThietBi" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ParentFieldName="id_parent" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" EnableTheming="True" EnableCallbacks="False">
                <Columns>
                    <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0" ShowInCustomizationForm="True">
                    </dx:TreeListTextColumn>
                    <dx:TreeListTextColumn Caption="#" Name="colchitiet" VisibleIndex="2">
                        <DataCellTemplate>
                            <a href="<%# Request.Url.AbsolutePath %>?id=<%# Eval("id")  %>">Chi tiết</a>
                        </DataCellTemplate>
                    </dx:TreeListTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedNode="True" />
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            </dx:ASPxTreeList>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
            </div>
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
        <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
    </asp:Panel>
</asp:Panel>

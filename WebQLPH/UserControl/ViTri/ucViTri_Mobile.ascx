<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucViTri_Mobile.ascx.cs" Inherits="WebQLPH.UserControl.ViTri.ucViTri_Mobile" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxImageSlider" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

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
            Vị trí
        </div>
        <dx:ASPxTreeList ID="ASPxTreeList_ViTri" runat="server" AutoGenerateColumns="False" KeyFieldName="id" ParentFieldName="parent_id" Theme="MetropolisBlue" ClientInstanceName="treeList" Width="100%" EnableTheming="True" OnCustomDataCallback="ASPxTreeList_ViTri_CustomDataCallback">
            <Columns>
                <dx:TreeListTextColumn Caption="Tên" FieldName="ten" Name="colten" VisibleIndex="0" ShowInCustomizationForm="True">
                </dx:TreeListTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedNode="True" FocusNodeOnExpandButtonClick="False" />
            <SettingsCookies Enabled="True" StoreExpandedNodes="True" StorePaging="True" />
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
            <ClientSideEvents CustomDataCallback="function(s, e) { document.location = e.result; }"
                Init="function(s, e) {
                    s.SetFocusedNodeKey('');
                }"
                NodeClick="function(s, e) {
	                var key = e.nodeKey;
	                treeList.PerformCustomDataCallback(key);
                }" />
        </dx:ASPxTreeList>
    </div>
    </asp:Panel>
    <asp:Panel ID="Panel_ThongTinObj" runat="server" Visible="False">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
            </div>
            <div class="panel-body">
                <div class="center200">
                    <dx:ASPxImageSlider ID="ASPxImageSlider_Object" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"></dx:ASPxImageSlider>
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
                            <asp:TextBox ID="TextBox_MoTa" CssClass="form-control" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="Button_Map" CssClass="btn btn-success" runat="server" Text="Xem bản đồ" OnClick="Button_Map_Click" Width="100px" />
        <asp:Button ID="Button_Back" CssClass="btn btn-default" runat="server" Text="Quay lại" OnClick="Button_Back_Click" Width="100px" />
    </asp:Panel>
</asp:Panel>
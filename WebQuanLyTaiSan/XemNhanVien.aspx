<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XemNhanVien.aspx.cs" Inherits="WebQuanLyTaiSan.XemNhanVien" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <dx:ASPxGridView ID="ASPxGridView" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="iOS">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Mã" Name="subId" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Tên" Name="hoten" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Điện thoại" Name="sodienthoai" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Hình" Name="hinh" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        </dx:ASPxGridView>
    
    </div>
    </form>
</body>
</html>

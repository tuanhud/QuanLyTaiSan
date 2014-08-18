<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhanVien_Web.ascx.cs" Inherits="WebQLPH.UserControl.NhanVien.ucNhanVien_Web" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxImageSlider" tagprefix="dx" %>
<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

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
                <td>
                    <div class="panel panel-primary">
        <div class="panel-heading">
            Danh sách nhân viên
        </div>
        <table class="table table-bordered table-striped">
            <thead class="centered">
                <tr>
                    <th>#</th>
                    <th>Mã nhân viên</th>
                    <th>Họ tên</th>
                    <th>Số điện thoại</th>
                </tr>
            </thead>
            <tbody class="centered">
                <asp:Repeater ID="RepeaterQuanLyNhanVien" runat="server">
                    <ItemTemplate> 
                        <%--<% if (check && id == 0)
                           { %>
                        <tr style="background: #ff00ff;">
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyNhanVien.CurrentPage - 1)*CollectionPagerQuanLyNhanVien.PageSize) %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("subid") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("hoten") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("sodienthoai") %></a></td>
                        </tr>
                        <% } else { %>
                        <tr>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyNhanVien.CurrentPage - 1)*CollectionPagerQuanLyNhanVien.PageSize) %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("subid") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("hoten") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("sodienthoai") %></a></td>
                        </tr>
                        <% } %>--%>
                        <tr>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Container.ItemIndex + 1 + ((CollectionPagerQuanLyNhanVien.CurrentPage - 1)*CollectionPagerQuanLyNhanVien.PageSize) %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("subid") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("hoten") %></a></td>
                            <td><a href="<% ResolveClientUrl("NhanVien.aspx"); %>?id=<%# Eval("id") %>"><%# Eval("sodienthoai") %></a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <% if (RepeaterQuanLyNhanVien.Items.Count == 0)
           { %>   
        <div class="panel-body">Chưa có nhân viên</div>
        <% } %>
    </div>
            
    <div class="leftCollectionPager">
        <div class="CollectionPager">
            <cp:CollectionPager ID="CollectionPagerQuanLyNhanVien" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="Trang" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static"></cp:CollectionPager>
        </div>
    </div>
                </td>
                <td>
                    
                    <div class="panel panel-primary">
        <div class="panel-heading">
            <asp:Label ID="Label_ThongTin" runat="server" Text="Thông tin"></asp:Label>
        </div>
        
        <div class="panel-body">
            <asp:Panel ID="PanelThongBao" runat="server" Visible="False">
    <div class="row">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-exclamation-sign"></span>
            <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>
            <div class="center">
                <dx:ASPxImageSlider ID="ImageSliderNhanVienPhuTrach" runat="server" BinaryImageCacheFolder="~\Thumb\" Height="200px" ShowNavigationBar="False" Width="200px"></dx:ASPxImageSlider>
            </div>
            <br />
            <div>
                <asp:Label ID="Label1" runat="server" Text="Mã nhân viên"></asp:Label>
                <asp:TextBox ID="TextBox_MaNhanVien" CssClass="form-control" placeholder="Mã nhân viên" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label2" runat="server" Text="Họ tên"></asp:Label>
                <asp:TextBox ID="TextBox_HoTen" CssClass="form-control" placeholder="Họ tên nhân viên" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label3" runat="server" Text="Số điện thoại"></asp:Label>
                <asp:TextBox ID="TextBox_SoDienThoai" CssClass="form-control" placeholder="Số điện thoại" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="panel panel-primary">
        <div class="panel-heading">
            Danh sách phòng
        </div>
        <ul class="list-group">
            <asp:Repeater ID="RepeaterDanhSachPhong" runat="server">
                <ItemTemplate>
                    <li class="list-group-item"><%# Eval("ten") %></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <% if (RepeaterDanhSachPhong.Items.Count == 0)
           { %>   
        <div class="panel-body">Không có phòng nào</div>
        <% } %>
    </div>

    <div class="leftCollectionPager">
        <div class="CollectionPager">
            <cp:CollectionPager ID="CollectionPagerDanhSachPhong" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="10" PagingMode="QueryString" QueryStringKey="TrangPhong" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static"></cp:CollectionPager>
        </div>
    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>




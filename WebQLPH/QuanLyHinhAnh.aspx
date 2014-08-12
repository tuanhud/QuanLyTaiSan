<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyHinhAnh.aspx.cs" Inherits="WebQLPH.QuanLyHinhAnh" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý hình ảnh</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading"><b>TẢI ẢNH LÊN</b></div>
        <div class="panel-body">
            <asp:Panel ID="PanelThongBao" runat="server" Visible="false">
                <asp:Label ID="LabelThongBao" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="LabelThongBaoAnhDaCo" runat="server" Text="Label" Visible="false"></asp:Label>
            </asp:Panel>
            <asp:FileUpload ID="ImageUpload" runat="server" CssClass="btn btn-success" AllowMultiple="True" ClientIDMode="Static" /><br />
            <asp:Button ID="ButtonTaiLen" CssClass="btn btn-success" runat="server" Text="Tải lên" OnClick="ButtonTaiLen_Click" />
        </div>
    </div>
    <div class="panel panel-info">
        <div class="panel-heading"><b>DANH SÁCH HÌNH ẢNH</b></div>
        <div class="panel-body">
            <div id="links">
                <asp:Repeater ID="RepeaterHinhAnh" runat="server">
                    <ItemTemplate>
                        <a href="<%#Url(Container.DataItem.ToString())%>" title="<%# Container.DataItem %>" data-gallery>
                            <img src="<%#Thumb(Container.DataItem.ToString())%>" alt="<%#Container.DataItem %>" title="<%# Container.DataItem %>" class="img-thumbnail" />
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="centerCollectionPager">
                <div class="CollectionPager">
                    <cp:CollectionPager ID="CollectionPagerQuanLyHinhAnh" runat="server" LabelText="" MaxPages="20" ShowLabel="False" BackNextDisplay="HyperLinks" BackNextLinkSeparator="" BackNextLocation="None" BackText="" EnableViewState="False" FirstText="&laquo;" LabelStyle="FONT-WEIGHT: blue;" LastText="&raquo;" NextText="" PageNumbersSeparator="" PageSize="3" PagingMode="QueryString" QueryStringKey="Trang" ResultsFormat="" ResultsLocation="None" ResultsStyle="" ShowFirstLast="True" ClientIDMode="Static">
                    </cp:CollectionPager>
                </div>
            </div>
        </div>
    </div>
    <!-- The Bootstrap Image Gallery lightbox, should be a child element of the document body -->
    <div id="blueimp-gallery" class="blueimp-gallery">
        <!-- The container for the modal slides -->
        <div class="slides"></div>
        <!-- Controls for the borderless lightbox -->
        <h3 class="title"></h3>
        <a class="prev">‹</a>
        <a class="next">›</a>
        <a class="close">×</a>
        <a class="play-pause"></a>
        <ol class="indicator"></ol>
        <!-- The modal dialog, which will be used to wrap the lightbox content -->
        <div class="modal fade" id="modelHinhAnh">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body next"></div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left prev">
                            <i class="glyphicon glyphicon-chevron-left"></i>
                            Ảnh trước
                        </button>
                        <button type="button" class="btn btn-primary next">
                            Ảnh kế
                        <i class="glyphicon glyphicon-chevron-right"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

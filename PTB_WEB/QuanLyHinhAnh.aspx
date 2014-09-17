<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="QuanLyHinhAnh.aspx.cs" Inherits="PTB_WEB.QuanLyHinhAnh" %>

<%@ Register TagPrefix="cp" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<%@ Register Src="~/UserControl/Alert/ucSuccess.ascx" TagPrefix="uc" TagName="ucSuccess" %>
<%@ Register Src="~/UserControl/Alert/ucWarning.ascx" TagPrefix="uc" TagName="ucWarning" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>
<%@ Register Src="~/UserControl/ucDangNhap.ascx" TagPrefix="uc" TagName="ucDangNhap" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Quản lý hình ảnh :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="QuanLyHinhAnh.aspx">Quản lý hình ảnh</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <asp:Panel ID="PanelDangNhap" runat="server" Visible="false">
                        <div class="center">
                            <uc:ucDangNhap runat="server" ID="ucDangNhap" />
                        </div>
                    </asp:Panel>
                    <uc:ucSuccess runat="server" ID="ucSuccess" Visible="false" />
                    <uc:ucWarning runat="server" ID="ucWarning" Visible="false" />
                    <uc:ucDanger runat="server" ID="ucDanger" Visible="false" />
                    <asp:Panel ID="PanelQuanLyHinhAnh" runat="server" Visible="false">
                        <h3 class="title_green fix">Tải ảnh lên</h3>
                        <asp:Panel ID="PanelThongBao" runat="server" Visible="false">
                            <asp:Label ID="LabelThongBao" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="LabelThongBaoAnhDaCo" runat="server" Text="Label" Visible="false"></asp:Label>
                        </asp:Panel>
                        <asp:FileUpload ID="ImageUpload" runat="server" Multiple="Multiple" ClientIDMode="Static" CssClass="btn btn-success" /><br />
                        <asp:Button ID="ButtonTaiLen" CssClass="btn btn-success" runat="server" Text="Tải lên" OnClick="ButtonTaiLen_Click" />
                        <h3 class="title_orange">Danh sách hình ảnh</h3>
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
                                <cp:CollectionPager
                                    ID="CollectionPagerQuanLyHinhAnh"
                                    runat="server"
                                    LabelText=""
                                    MaxPages="5"
                                    ShowLabel="False"
                                    BackNextDisplay="HyperLinks"
                                    BackNextLinkSeparator=""
                                    BackNextLocation="None"
                                    BackText="Trước"
                                    EnableViewState="False"
                                    FirstText="Đầu"
                                    LastText="Cuối"
                                    NextText="Sau"
                                    PageNumbersSeparator=""
                                    PageSize="10"
                                    PagingMode="QueryString"
                                    QueryStringKey="Trang"
                                    ResultsFormat=""
                                    ResultsLocation="None"
                                    ResultsStyle=""
                                    ShowFirstLast="False"
                                    ClientIDMode="Static">
                                </cp:CollectionPager>
                            </div>
                        </div>
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
                    </asp:Panel>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

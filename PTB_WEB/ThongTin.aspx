<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ThongTin.aspx.cs" Inherits="PTB_WEB.ThongTin" %>

<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Thông tin :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="ThongTin.aspx">Thông tin</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <h3 class="title_green fix">Thông tin phần mềm</h3>
                    <%--<div class="row" style="width:100%">
                        <div class="col-lg-6">
                            <img src="Images/thongtinphanmem.png" alt="Thông tin phần mềm" class="img-thumbnail" />
                        </div>
                        <div class="col-lg-4">
                            <p>Phần mềm Quản lý Phòng Thiết bị phiên bản 1.0</p>
                            <p>
                                <asp:Button ID="ButtonDownload" runat="server" Text="Download" CssClass="btn btn-success" OnClientClick="alert('Chưa có link download'); return false;" />
                            </p>
                        </div>
                    </div>
                    <h3 class="title_green">Thông tin website</h3>
                    <div class="row" style="width:100%">
                        <div class="col-lg-6">
                            <img src="Images/thongtinwebsite.png" alt="Thông tin website" class="img-thumbnail" />
                        </div>
                        <div class="col-lg-4">
                            <p>Website Quản lý Phòng Thiết bị phiên bản 1.0</p>
                        </div>
                    </div>--%>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

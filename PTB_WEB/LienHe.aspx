<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="PTB_WEB.LienHe" %>

<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>
<%@ Register Src="~/UserControl/Alert/ucSuccess.ascx" TagPrefix="uc" TagName="ucSuccess" %>
<%@ Register Src="~/UserControl/Alert/ucDanger.ascx" TagPrefix="uc" TagName="ucDanger" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Liên hệ :: Phòng Thiết bị :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li><a href="Default.aspx"><span class="glyphicon glyphicon-home"></span></a></li>
        <li><a href="LienHe.aspx">Liên hệ</a></li>
    </ol>
    <table class="table largetable">
        <tbody>
            <tr>
                <td>
                    <uc:ucSuccess runat="server" ID="ucSuccess" Visible="false" />
                    <uc:ucDanger runat="server" ID="ucDanger" Visible="false" />
                    <asp:Panel ID="PanelInfo" runat="server">
                        <h3 class="title_green fix">Liên hệ với chúng tôi</h3>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Họ và Tên (*)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Email (*)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Điện thoại (*)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBoxDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Nội dung (*)</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBoxNoiDung" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="ButtonLienHe" runat="server" Text="Gửi" CssClass="btn btn-success" OnClick="ButtonLienHe_Click" />
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

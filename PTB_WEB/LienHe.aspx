<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="PTB_WEB.LienHe" %>

<%@ Register Src="~/UserControl/ucFooter.ascx" TagPrefix="uc" TagName="ucFooter" %>


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
                    <h3 class="title_green fix">Liên hệ với chúng tôi</h3>
                    <div class="col-lg-12">
                        <asp:Panel ID="PanelThongBao" runat="server" Visible="false">
                            <div class="alert alert-warning alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <span class="glyphicon glyphicon-info-sign"></span>
                                <asp:Label ID="LabelThongBao" runat="server" Text="Label"></asp:Label>
                            </div>
                        </asp:Panel>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Họ và Tên</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextHoVaTen" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Điện thoại</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextBoxDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Nội dung</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextBoxNoiDung" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="ButtonLienHe" runat="server" Text="Gửi" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <uc:ucFooter runat="server" ID="ucFooter" />
</asp:Content>

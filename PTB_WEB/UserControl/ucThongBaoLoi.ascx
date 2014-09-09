<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThongBaoLoi.ascx.cs" Inherits="PTB_WEB.UserControl.ucThongBaoLoi" %>
<asp:Panel ID="Panel_ThongBaoLoi" runat="server" Visible="False">
    <table class="table largetable fixheight">
        <tbody>
            <tr>
                <td>
                    <div class="alert alert-danger" role="alert">
                        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <span class="glyphicon glyphicon-exclamation-sign"></span>
                        <asp:Label ID="Label_ThongBaoLoi" runat="server" Text="Label"></asp:Label>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>

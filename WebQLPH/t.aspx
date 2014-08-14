<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="WebQLPH.t" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server" enctype="multipart/form-data">
    <div>
        <input id="filMyFile" type="file" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>

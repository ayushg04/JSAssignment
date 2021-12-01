<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="FileUpload.Sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample Page </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSampleMsg" runat="server" ForeColor="Black" Font-Bold="true" Text="Dummy Page" />
            <asp:Button ID="btnBack" runat="server" ForeColor="Black" Font-Bold="true" Text="Back Button" OnClick="btnBack_Click" Height="30px" />
        </div>
    </form>
</body>
</html>

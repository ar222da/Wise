<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication7.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Ny student</h2>
 
        Namn:
        <asp:TextBox id="tb1" runat="server" />
        <br /><br />

        Adress:
        <asp:TextBox id="TextBox1" runat="server" />
        <br /><br />

        Postnummer:
        <asp:TextBox id="TextBox2" runat="server" />
        <br /><br />

        Ort:
        <asp:TextBox id="TextBox3" runat="server" />
        <br /><br />

        Telefon:
        <asp:TextBox id="TextBox4" runat="server" />
        <br /><br />

    </div>

    </form>

</body>
</html>

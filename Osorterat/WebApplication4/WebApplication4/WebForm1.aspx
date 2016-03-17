<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
        <p>
            <asp:Label ID="Label1" runat="server">ASP.NET Web forms (1DV406) </asp:Label>
        </p>

        <h1>
            <asp:Label ID="Label2" runat="server">Hur många versaler?</asp:Label>
        </h1>    
    </div>

    <div id="border">
    </div>

    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
        <asp:Label ID="NumberOfCapitals" runat="server" Text=""></asp:Label>

        <asp:Button ID="Button1" runat="server" Text="Bestäm antalet versaler" OnClick="Button1_Click" />
    </form>
</body>
</html>

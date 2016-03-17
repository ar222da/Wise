<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5.WebForm1" ViewStateMode ="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
    <p><asp:Label ID="Label1" runat="server" Text="ASP.NET Webforms (1DV406)"></asp:Label></p>
    <p><asp:Label ID="Label2" runat="server" Text="Steg 1"></asp:Label></p>
    <p><asp:Label ID="Label3" runat="server" Text="Laborationsuppgift 3"></asp:Label></p>
    
    <h1><asp:Label ID="Label4" runat="server" Text="Konvertera temperaturer"></asp:Label></h1>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fyll i en starttemperatur." Display="Dynamic" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Fyll i en starttemperatur." Type="Integer" ControlToValidate="TextBox1" Operator="DataTypeCheck"></asp:CompareValidator>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fyll i slutttemperaturen." Display="Dynamic" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ErrorMessage="Fyll i sluttemperaturen." Type="Integer" ControlToValidate="TextBox2" Operator="DataTypeCheck"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Fyll i en sluttemperatur högre än starttemperaturen." Operator="GreaterThan" Type="String" ValueToCompare="TextBox1.Value" ControlToValidate="TextBox2" ControlToCompare="TextBox1" Display="Dynamic"></asp:CompareValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fyll i ett temperatursteg." Display="Dynamic" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator3" runat="server" Display="Dynamic" ErrorMessage="Fyll i ett temperatursteg." Type="Integer" ControlToValidate="TextBox3" Operator="DataTypeCheck"></asp:CompareValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Fyll i temperatursteget så att det är ett heltal mellan 1 och 100." ControlToValidate="TextBox3" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>



    <p><asp:Label ID="Label5" runat="server" Text="Starttemperatur:"></asp:Label></p>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    <p><asp:Label ID="Label6" runat="server" Text="Sluttemperatur:"></asp:Label></p>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    
    <p><asp:Label ID="Label7" runat="server" Text="Temperatursteg:"></asp:Label></p>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    
    <asp:RadioButton ID="RadioButton1" runat="server" Text="Celsius till Fahrenheit" GroupName="Radiobuttons" Checked="True" />
    <asp:RadioButton ID="RadioButton2" runat="server" Text="Fahrenheit till Celsius" GroupName="Radiobuttons" />
    
    <asp:Button ID="Button1" runat="server" Text="Konvertera" />     
    </asp:Panel>        
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication8.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Galleri</h1>
        <asp:Image ID="Image1" runat="server" ImageUrl='~/Content/bild004.jpg' Visible="false"/>            
        <asp:Repeater ID="Repeater" runat="server" ItemType="System.String" SelectMethod="Repeater_GetData">
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" ImageUrl='<%# "~/Content/Thumbnail/" + Item %>'
                    PostBackUrl ='<%# "~/Default.aspx?FileName=" + Item %>' /> 
            </ItemTemplate>
        </asp:Repeater>
        
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Fel inträffade!" runat="server" DisplayMode="BulletList" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ErrorMessage="En fil måste väljas." ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ErrorMessage="Endast bilder av typerna gif, jpeg eller png är tillåtna." ControlToValidate="FileUpload1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:Button ID="Button1" runat="server" Text="Ladda upp" OnClick="Button1_Click" />
    
    </div>
    </form>
</body>
</html>

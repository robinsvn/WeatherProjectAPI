<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WeatherProjectAPI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelTemp" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="LabelWind" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="LabelWindDirection" runat="server" Text="Label"></asp:Label><br />
            <asp:Label ID="Labelukjentligning" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="Buttonreversetext" runat="server" Text="Reverse" OnClick="Buttonreversetext_Click" />
        </div>
    </form>
</body>
</html>

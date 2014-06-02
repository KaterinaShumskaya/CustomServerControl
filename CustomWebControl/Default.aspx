<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomWebControl.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <Custom:TextWithCaptionControl runat="server" Text = "30$" Caption="Цена" Alignment="Left" Separator="Colon" TextColor="Blue"/>
        </div>
    </form>
</body>
</html>

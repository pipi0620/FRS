<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 435px">
    <asp:Label runat="server" Text="Welcome to our Travel Reservation System" Font-Italic="True" Font-Names="Calibri" Height="60px"></asp:Label>
    <form id="form1" runat="server">
        <div style="height: 407px">
            <asp:Label ID="Label1" runat="server" Text="Please select the additional service you need: " Font-Names="Calibri" Font-Size="Medium"></asp:Label>      
            <br />
            <br />
            <asp:CheckBoxList ID="checkbox" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" Font-Names="Calibri" BackColor="#FFCCCC">
                <asp:ListItem>Hotel Reservation Service</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="start" runat="server" Text="start"  OnClick="BtnPost_Click" Font-Bold="True" Font-Names="Calibri" Height="50px" Width="120px" Font-Size="Large"/>

             
            </div>
    </form>
</body>   
</html>


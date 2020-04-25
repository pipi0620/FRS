<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 435px">
    <asp:Label runat="server" Text="Welcome to our Travel Reservation System"></asp:Label>
    <form id="form1" runat="server">
        <div style="height: 407px">
            <asp:Label ID="Label1" runat="server" Text="Please select the extra service you need: "></asp:Label>      
            <br />
            <asp:CheckBoxList ID="service1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>Hotel Reservation Service</asp:ListItem>
                <asp:ListItem>Car Rental Service</asp:ListItem>
            </asp:CheckBoxList>

             
            <br />
            <br />
            <asp:Button ID="start" runat="server" Text="start"  OnClick="BtnPost_Click"/>

             
            </div>
    </form>
</body>   
</html>

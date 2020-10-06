<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PS.aspx.cs" Inherits="WebRole1.PS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Payment Service" Font-Italic="True" Font-Names="Calibri" Height="60px"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Card holder: " Height="30px" Width="150px" Font-Bold="False" Font-Names="Calibri"></asp:Label> 
            <asp:Textbox ID="TxtName" runat="server" Text="" Width="250px" Height="30px"></asp:Textbox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Card number: " ForeColor="Black" Height="30px" Width="150px" Font-Names="Calibri"></asp:Label> 
            <asp:Textbox ID="TxtCardNumber" runat="server" Text="" Width="250px" BackColor="White" Height="30px"></asp:Textbox>
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="Passport Number:" Font-Names="Calibri" Height="30px" Width="165px"></asp:Label>
            <asp:TextBox ID="passport" runat="server" Height="30px" Width="120px" AutoPostBack="True"></asp:TextBox>

            &nbsp<br />
           
        </div>
        <br />
            <br />
        <asp:Button ID="BtnPost" runat="server" Text="Get your price" Width="200px" Height="50px" OnClick="BtnPost_Click" style="margin-top: 0px" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Button>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Total fare of all services above is " Font-Names="Calibri" Font-Size="Large" Font-Italic="True" ></asp:Label>
            <asp:Textbox ID="TxtPrice" runat="server" Text="" Width="150px" BackColor="#FFFFCC" Height="30px" Font-Names="Calibri" Font-Size="Larger"></asp:Textbox>
            <asp:Label ID="Label11" runat="server" Text="SEK" Font-Names="Calibri" Font-Size="Large" Font-Italic="True"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="View Report" Width="200px" Height="50px" OnClick="BtnReport_Click" style="margin-top: 0px" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Button>
        </form>
    
</body>
</html>

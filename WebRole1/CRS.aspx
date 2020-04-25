<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRS.aspx.cs" Inherits="WebRole1.CRS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 435px">
    <form id="form1" runat="server">
        <div style="height: 407px">
            <asp:Label ID="Label1" runat="server" Text="Number of seats: "></asp:Label> 
            <asp:Textbox ID="SeatNumber" runat="server" Text="" Width="306px"></asp:Textbox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Model year: " ></asp:Label> 
            <asp:Textbox ID="Model" runat="server" Text="" Width="306px"></asp:Textbox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Driver age: "></asp:Label>
            <asp:Textbox ID="DriverAge" runat="server" Text="" Width="306px"></asp:Textbox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Option for fuel type: "></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Diesel</asp:ListItem>
                <asp:ListItem>Benzene</asp:ListItem>
            </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnContinue" runat="server" Text="Continue" onclick="BtnContinue_Click"></asp:Button>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click"></asp:Button>
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp

            <br />
            
            </div>
    </form>
</body>
</html>

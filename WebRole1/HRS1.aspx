<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRS1.aspx.cs" Inherits="WebRole1.HRS1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 435px">
    <form id="form1" runat="server">
        <div style="height: 407px">
            <asp:Label ID="Label1" runat="server" Text="Number of travellers: " Height="40px" Width="200px" Font-Bold="False" Font-Names="Calibri"></asp:Label> 
            <asp:Textbox ID="TxtNumTraveller" runat="server" Text="" Width="160px" Height="40px"></asp:Textbox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Number of nights: " ForeColor="Black" Height="40px" Width="200px" Font-Names="Calibri"></asp:Label> 
            <asp:Textbox ID="TxtNumNight" runat="server" Text="" Width="160px" BackColor="White" Height="40px"></asp:Textbox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Number of seniors: " Height="40px" Width="200px" Font-Names="Calibri"></asp:Label>
            <asp:Textbox ID="TxtNumSenior" runat="server" Text="" Width="160px" Height="40px"></asp:Textbox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Name of primary guest: " Height="40px" Width="200px" Font-Names="Calibri"></asp:Label>
            <asp:Textbox ID="TxtGuestName" runat="server" Text="" Width="160px" BackColor="White" Height="40px"></asp:Textbox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Option for room type: " Height="40px" Width="200px" Font-Names="Calibri"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="27px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>Single</asp:ListItem>
                <asp:ListItem>Double</asp:ListItem>
            </asp:RadioButtonList>
        <br />
            <asp:Button ID="btnContinue" runat="server" Text="Continue" onclick="BtnContinue_Click" Width="150px" Height="40px"></asp:Button>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" Width="150px" Height="40px"></asp:Button>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp

            <br />
            
            </div>
    </form>
</body>
</html>

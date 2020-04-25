<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRS.aspx.cs" Inherits="WebRole1.FRS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 435px">
    <form id="form1" runat="server">
        <div style="height: 407px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Welcome to CharterResor, Your Ultimate Flight Companion!"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="From:"></asp:Label>
            <asp:DropDownList ID="from" runat="server">
                <asp:ListItem>STO</asp:ListItem>
                <asp:ListItem>CPH</asp:ListItem>
                <asp:ListItem>CDG</asp:ListItem>
                <asp:ListItem>LHR</asp:ListItem>
                <asp:ListItem>FRA</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label5" runat="server" Text="To:"></asp:Label>
            <asp:DropDownList ID="to" runat="server">
                <asp:ListItem>STO</asp:ListItem>
                <asp:ListItem>CPH</asp:ListItem>
                <asp:ListItem>CDG</asp:ListItem>
                <asp:ListItem>LHR</asp:ListItem>
                <asp:ListItem>FRA</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Month:"></asp:Label>
            <asp:DropDownList ID="month" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Number of Passengers:"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Infants(&lt;2):"></asp:Label>
            <asp:TextBox ID="infant" runat="server" style="margin-bottom: 0px">0</asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Children:"></asp:Label>
            <asp:TextBox ID="child" runat="server">0</asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Adults:"></asp:Label>
            <asp:TextBox ID="adult" runat="server">0</asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Seniors(&gt;65):"></asp:Label>
            <asp:TextBox ID="senior" runat="server">0</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnPost" runat="server" Text="Get your price" Width="182px" Height="45px" OnClick="BtnPost_Click" style="margin-top: 0px"></asp:Button>
            <br />
            &nbsp;<asp:Label ID="Label10" runat="server" Text="Current price for the above passenger is: "></asp:Label>
            <asp:Textbox ID="TxtMyName" runat="server" Text="" Width="186px" BackColor="#FFFFCC" Height="33px"></asp:Textbox>
            &nbsp;<asp:Label ID="Label11" runat="server" Text="SEK"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp&nbsp&nbsp
            <br />
            
            </div>
    </form>
</body>
</html>

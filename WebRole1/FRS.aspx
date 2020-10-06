<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRS.aspx.cs" Inherits="WebRole1.FRS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 600px">
    <form id="form1" runat="server">
        <div style="height: 600px">
            <asp:Label ID="Label1" runat="server" Text="Flight Reservation Service" Font-Italic="True" Font-Names="Calibri" Height="60px"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="From:" Font-Names="Calibri" Height="30px" Width="65px"></asp:Label>
            <asp:DropDownList ID="from" runat="server" Height="30px" Width="120px" AutoPostBack="True">
                <asp:ListItem>STO</asp:ListItem>
                <asp:ListItem>CPH</asp:ListItem>
                <asp:ListItem>CDG</asp:ListItem>
                <asp:ListItem>LHR</asp:ListItem>
                <asp:ListItem>FRA</asp:ListItem>
            </asp:DropDownList>
            &nbsp
            <asp:Label ID="Label5" runat="server" Text="To:" Font-Names="Calibri" Height="30px" Width="35px"></asp:Label>
            <asp:DropDownList ID="to" runat="server" Height="30px" Width="120px" AutoPostBack="True">
                <asp:ListItem>STO</asp:ListItem>
                <asp:ListItem>CPH</asp:ListItem>
                <asp:ListItem>CDG</asp:ListItem>
                <asp:ListItem>LHR</asp:ListItem>
                <asp:ListItem>FRA</asp:ListItem>
            </asp:DropDownList>
            &nbsp
            <asp:Label ID="Label6" runat="server" Text="Month:" Font-Names="Calibri" Height="30px" Width="65px"></asp:Label>
            <asp:DropDownList ID="month" runat="server" Height="30px" Width="100px" AutoPostBack="True">
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
            <asp:Label ID="Label9" runat="server" Text="Flight Number:" Font-Names="Calibri" Height="30px" Width="130px"></asp:Label>
            <asp:ListBox ID="flight" runat="server" DataSourceID="SqlDataSource1" DataTextField="Flight_number" DataValueField="Flight_number" Height="32px" Width="140px" AutoPostBack="True"></asp:ListBox>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="Flight_number" HeaderText="Flight_number" SortExpression="Flight_number" />
                    <asp:BoundField DataField="Carrier" HeaderText="Carrier" SortExpression="Carrier" />
                    <asp:BoundField DataField="Departure_airport" HeaderText="Departure_airport" SortExpression="Departure_airport" />
                    <asp:BoundField DataField="Arrival_airport" HeaderText="Arrival_airport" SortExpression="Arrival_airport" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lichdatabaseConnectionString %>" SelectCommand="SELECT [Flight_number], [Carrier], [Departure_airport], [Arrival_airport] FROM [Routes] WHERE (([Departure_airport] = @Departure_airport) AND ([Arrival_airport] = @Arrival_airport))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="from" Name="Departure_airport" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="to" Name="Arrival_airport" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Passenger Information:" Font-Names="Calibri" Height="30px"></asp:Label>
            <br />
            <br />
            <asp:Label ID="label31" runat="server" Text="Infants(<2):" Font-Names="Calibri" Height="30px" Width="120px"></asp:Label>
            <asp:TextBox ID="infant" runat="server" style="margin-bottom: 0px" Height="30px" Width="80px" AutoPostBack="True">0</asp:TextBox>
            &nbsp; <asp:Label ID="label32" runat="server" Text="Children:" Font-Names="Calibri" Height="30px" Width="120px"></asp:Label>
            <asp:TextBox ID="child" runat="server" style="margin-bottom: 0px" Height="30px" Width="80px" AutoPostBack="True">0</asp:TextBox>
            &nbsp;
            <br /> <asp:Label ID="label33" runat="server" Text="Adults:" Font-Names="Calibri" Height="30px" Width="120px"></asp:Label>
            <asp:TextBox ID="adult" runat="server" style="margin-bottom: 0px" Height="30px" Width="80px" AutoPostBack="True">0</asp:TextBox>
            &nbsp; <asp:Label ID="label34" runat="server" Text="Seniors(>65):" Font-Names="Calibri" Height="30px" Width="120px"></asp:Label>
           
            <asp:TextBox ID="senior" runat="server" style="margin-bottom: 0px" Height="30px" Width="80px" AutoPostBack="True">0</asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnContinue" runat="server" Text="Continue" onclick="BtnContinue_Click" Width="120px" Height="50px" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Button>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="BtnCancel_Click" Width="120px" Height="50px" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"></asp:Button>
            </div>
    </form>
</body>
</html>

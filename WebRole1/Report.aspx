<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebRole1.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
      
         <asp:Label ID="CardList" runat="server"></asp:Label>

         <asp:Label ID="Transactions" runat="server"></asp:Label>

            <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="Airport_code" HeaderText="Airport_code" SortExpression="Airport_code" />
                <asp:BoundField DataField="Airport_city" HeaderText="Airport_city" SortExpression="Airport_city" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" SortExpression="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" SortExpression="Longitude" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:lichdatabaseConnectionString3 %>" SelectCommand="SELECT [Airport_code], [Airport_city], [Latitude], [Longitude] FROM [Airports]"></asp:SqlDataSource>
            <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Airline_code" HeaderText="Airline_code" SortExpression="Airline_code" />
                <asp:BoundField DataField="Airline_name" HeaderText="Airline_name" SortExpression="Airline_name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lichdatabaseConnectionString2 %>" SelectCommand="SELECT [Airline_code], [Airline_name] FROM [Airlines]"></asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4">
                <Columns>
                    <asp:BoundField DataField="Flight_number" HeaderText="Flight_number" SortExpression="Flight_number" />
                    <asp:BoundField DataField="Carrier" HeaderText="Carrier" SortExpression="Carrier" />
                    <asp:BoundField DataField="Departure_airport" HeaderText="Departure_airport" SortExpression="Departure_airport" />
                    <asp:BoundField DataField="Arrival_airport" HeaderText="Arrival_airport" SortExpression="Arrival_airport" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:lichdatabaseConnectionString4 %>" SelectCommand="SELECT [Flight_number], [Carrier], [Departure_airport], [Arrival_airport] FROM [Routes]"></asp:SqlDataSource>
            <br />
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" >
                <Columns>
                    <asp:BoundField DataField="Passenger_name" HeaderText="Passenger_name" SortExpression="Passenger_name" />
                    <asp:BoundField DataField="Flight_number" HeaderText="Flight_number" SortExpression="Flight_number" />
                    <asp:BoundField DataField="Departure_date" HeaderText="Departure_date" SortExpression="Departure_date" />
                    <asp:BoundField DataField="Air_fare" HeaderText="Air_fare" SortExpression="Air_fare" />
                    <asp:BoundField DataField="Passport_number" HeaderText="Passport_number" SortExpression="Passport_number" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:lichdatabaseConnectionString %>" SelectCommand="SELECT [Passenger_name], [Flight_number], [Departure_date], [Air_fare], [Passport_number] FROM [Flights]">
            </asp:SqlDataSource></div>
            </form>
</body>
</html>

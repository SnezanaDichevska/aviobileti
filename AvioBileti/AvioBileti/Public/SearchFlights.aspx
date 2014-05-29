<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchFlights.aspx.cs" Inherits="AvioBileti.SearchFlights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 226px;
        }
        .style10
        {
            width: 100%;
            
        }
        .style11
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FlightSearchSpace" runat="server">
    <table align="center" class="style10">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblAccessMessage" runat="server" Font-Bold="True" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                Тргнување од:&nbsp;&nbsp;</td>
            <td align="center">
                Одење до :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style11">
    <asp:TextBox ID="tbFrom" runat="server" Width="126px" 
        ></asp:TextBox>
                <asp:ImageButton ID="btnCal1" runat="server" Height="17px" 
        ImageUrl="~/img/calendarimage.jpg" onclick="btnCal1_Click" Width="22px" />
            </td>
            <td align="center" class="style11">
    <asp:TextBox ID="tbTo" runat="server"></asp:TextBox>
    <asp:ImageButton ID="btnCal2" runat="server" Height="17px" 
        ImageUrl="~/img/calendarimage.jpg" onclick="btnCal2_Click" Width="21px" />
            </td>
        </tr>
        <tr>
            <td align="center" height="16px" width="200px">
    <asp:Calendar ID="fromCalendar" runat="server" BackColor="White" 
        BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" 
        ForeColor="Black" Height="16px" Width="200px" CellPadding="4" 
        DayNameFormat="Shortest" Enabled="False" 
        onselectionchanged="fromCalendar_SelectionChanged" Visible="False">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
            </td>
            <td align="center" height="16px" width="200px">
    <asp:Calendar ID="toCalendar" runat="server" BackColor="White" 
        BorderColor="#999999" Font-Names="Verdana" Font-Size="8pt" 
        ForeColor="Black" Height="16px" Width="200px" CellPadding="4" 
        DayNameFormat="Shortest" Enabled="False" 
        onselectionchanged="toCalendar_SelectionChanged" Visible="False">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" rowspan="80">
                <asp:Button ID="btnSearchFlights" runat="server" Text="Пребарај" />
            </td>
        </tr>
    </table>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p align="center">
    &nbsp;&nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LoginSpace" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentSpace" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvFlights" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </p>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>

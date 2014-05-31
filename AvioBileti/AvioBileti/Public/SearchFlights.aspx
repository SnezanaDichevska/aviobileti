<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SearchFlights.aspx.cs" Inherits="AvioBileti.SearchFlights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FlightSearchSpace" runat="server">
    <table align="center" style="margin-top: 50px">
        <tr>
            <td>
                <asp:Label ID="lblAccessMessage" runat="server" CssClass="error"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Почетна дестинација:
            </td>
            <td class="width50" />
            <td>
                Крајна дестинација:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="cellSize">
                </asp:DropDownList>
            </td>
            <td class="width50" />
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="cellSize">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Датум на тргнување:
            </td>
            <td class="width50" />
            <td>
                Датум на враќање:
            </td>
            <td class="width50" />
            <td rowspan="2">
                <asp:Button ID="btnSearchFlights" runat="server" Text="Пребарај" CssClass="btn btn-info" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbFrom" runat="server" CssClass="cellSize"></asp:TextBox>
                <asp:ImageButton ID="btnCal1" runat="server" Height="17px" ImageUrl="~/Images/calendarimage.jpg"
                    OnClick="btnCal1_Click" />
            </td>
            <td class="width50" />
            <td>
                <asp:TextBox ID="tbTo" runat="server" CssClass="cellSize"></asp:TextBox>
                <asp:ImageButton ID="btnCal2" runat="server" Height="17px" ImageUrl="~/Images/calendarimage.jpg"
                    OnClick="btnCal2_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Calendar ID="fromCalendar" runat="server" BackColor="White" BorderColor="#999999"
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px"
                    CellPadding="4" DayNameFormat="Shortest" Enabled="False" OnSelectionChanged="fromCalendar_SelectionChanged"
                    Visible="False">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                        Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td class="width50" />
            <td align="center" height="16px" width="200px">
                <asp:Calendar ID="toCalendar" runat="server" BackColor="White" BorderColor="#999999"
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px"
                    CellPadding="4" DayNameFormat="Shortest" Enabled="False" OnSelectionChanged="toCalendar_SelectionChanged"
                    Visible="False">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                        Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentSpace" runat="server">
    <p>
        <asp:GridView ID="gvFlights" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

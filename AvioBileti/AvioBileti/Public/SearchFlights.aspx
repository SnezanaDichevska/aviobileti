<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SearchFlights.aspx.cs" Inherits="AvioBileti.SearchFlights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FlightSearchSpace" runat="server">
    <div class="set-margin">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblAccessMessage" runat="server" CssClass="error"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    Почетна дестинација:
                </td>
                <td class="width50" />
                <td>
                    Крајна дестинација:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddFromDestination" runat="server" CssClass="cellSize" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddFromDestination_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="width50" />
                <td>
                    <asp:DropDownList ID="ddToDestination" runat="server" CssClass="cellSize" 
                        AutoPostBack="True">
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
                    <asp:Button ID="btnSearchFlights" runat="server" Text="Пребарај" 
                        CssClass="btn btn-info" onclick="btnSearchFlights_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbTrgnuvanjeDatum" runat="server" CssClass="cellSize"></asp:TextBox>
                    <asp:ImageButton ID="btnCal1" runat="server" Height="17px" ImageUrl="~/Images/calendarimage.jpg"
                        OnClick="btnCal1_Click" />
                </td>
                <td class="width50" />
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbVrakjanjeDatum" runat="server" CssClass="cellSize"></asp:TextBox>
                    <asp:ImageButton ID="btnCal2" runat="server" Height="17px" ImageUrl="~/Images/calendarimage.jpg"
                        OnClick="btnCal2_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Calendar ID="trgnuvanjeCalendar" runat="server" BackColor="White" BorderColor="#999999"
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px"
                        CellPadding="4" DayNameFormat="Shortest" Enabled="False" OnSelectionChanged="trgnuvanjeCalendar_SelectionChanged"
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
                    <asp:Calendar ID="vrakjanjeCalendar" runat="server" BackColor="White" BorderColor="#999999"
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="16px" Width="200px"
                        CellPadding="4" DayNameFormat="Shortest" Enabled="False" OnSelectionChanged="vrakjanjeCalendar_SelectionChanged"
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
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentSpace" runat="server">
    <asp:GridView ID="gvLetoviTrgnuvanje" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" CellSpacing="3" 
        onselectedindexchanged="gvLetoviTrgnuvanje_SelectedIndexChanged" 
        DataKeyNames="IDL">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="IDL" Visible="False" />
        <asp:BoundField DataField="PGRAD" HeaderText="Појдовна дестинација" />
        <asp:BoundField DataField="KGRAD" HeaderText="Крајна дестинација" />
        <asp:BoundField DataField="datumLet" DataFormatString="{0:d}" 
                    HeaderText="Датум" />
        <asp:BoundField DataField="cena" HeaderText="Цена" />
        <asp:BoundField DataField="vremep" HeaderText="Полетување" />
        <asp:BoundField DataField="vremes" HeaderText="Слетување" />
        <asp:HyperLinkField NavigateUrl="~/User/MakeAReservation.aspx" />
        <asp:CommandField SelectText="Резервирај" ShowSelectButton="True" />
    </Columns>
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
<asp:GridView ID="gvLetoviVrakjanje" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" CellSpacing="3" 
        onselectedindexchanged="gvLetoviVrakjanje_SelectedIndexChanged" 
        DataKeyNames="IDL">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="IDL" Visible="False" />
        <asp:BoundField DataField="PGRAD" HeaderText="Појдовна дестинација" />
        <asp:BoundField DataField="KGRAD" HeaderText="Крајна дестинација" />
        <asp:BoundField DataField="datumLet" DataFormatString="{0:d}" 
                    HeaderText="Датум" />
        <asp:BoundField DataField="cena" HeaderText="Цена" />
        <asp:BoundField DataField="vremep" HeaderText="Полетување" />
        <asp:BoundField DataField="vremes" HeaderText="Слетување" />
        <asp:CommandField SelectText="Резервирај" ShowSelectButton="True" />
    </Columns>
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
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRezerviraj" runat="server" onclick="btnRezerviraj_Click" 
        Text="Резервирај" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AdvertisingSpace" runat="server">
</asp:Content>